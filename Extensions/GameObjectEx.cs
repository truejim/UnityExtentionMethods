using UnityEngine;

public static class GameObjectEx 
{
	/// <summary>
	/// Set the layer for game object and all its childs recursively.
	/// </summary>
	/// <param name="layer">The layer for game objects.</param>
	public static void SetLayerRecursively(this GameObject gameObject, int layer) {
		gameObject.layer = layer;
		foreach (Transform child in gameObject.transform)
			child.gameObject.SetLayerRecursively(layer);
	}

	/// <summary>
	/// Set the layer for game object and all its childs recursively.
	/// </summary>
	/// <param name="layer">The layer for game objects.</param>
	public static void SetLayerRecursively(this GameObject gameObject, string layerName) {
		int layer = LayerMask.NameToLayer(layerName);
		gameObject.layer = layer;
		foreach (Transform child in gameObject.transform)
			child.gameObject.SetLayerRecursively(layer);
	}

	/// <summary>
	/// Set the tag for game object and all its childs recursively.
	/// </summary>
	/// <param name="tag">The tag for game objects.</param>
	public static void SetTagRecursively(this GameObject gameObject, string tag) {
		gameObject.tag = tag;
		foreach (Transform child in gameObject.transform)
			child.gameObject.SetTagRecursively(tag);
	}

	public static void AddChild(this GameObject gameObject, GameObject childGameObject) {
		childGameObject.transform.SetParent(gameObject.transform, false);
	}

	public static void AddChild(this GameObject gameObject, GameObject childGameObject, bool worldPositionStays) {
		childGameObject.transform.SetParent(gameObject.transform, worldPositionStays);
	}

	public static void AddChild(this GameObject gameObject, Transform childTransform) {
		childTransform.SetParent(gameObject.transform, false);
	}

	public static void AddChild(this GameObject gameObject, Transform childTransform, bool worldPositionStays) {
		childTransform.SetParent(gameObject.transform, worldPositionStays);
	}

	public static void DestroyAllChildrens(this GameObject gameObject) {
		gameObject.transform.DestroyAllChildrens();
	}
	
	 public static GameObject CloneAt(this GameObject obj, Vector3 position) {
            GameObject obj2 = GameObject.Instantiate<GameObject>(obj);
            obj2.transform.position = position;
            return obj2;
        }
	 
	 public static GameObject Clone(this GameObject obj) {
		 GameObject obj2 = GameObject.Instantiate<GameObject>(obj);
		 return obj2;
	 }

	  public static IEnumerable<Transform> GetAllChildren(this Transform transform)
    {
        var stack = new Stack<Transform>();
        stack.Push(transform);
        while(stack.Count != 0)
        {
            var t = stack.Pop();
            yield return t;

            for (int i = 0; i < t.childCount; i++)
            {
                stack.Push(t.GetChild(i));
            }
        }
    }

    public static IEnumerable<GameObject> GetAllChildren(this GameObject gameObject)
    {
        var all = gameObject.transform.GetAllChildren();
        foreach(Transform t in all)
        {
            yield return t.gameObject;
        }
    }
}
