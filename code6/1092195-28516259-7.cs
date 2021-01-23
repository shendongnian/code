	public static IEnumerable<T> Search<T>(this T node, Func<T, IEnumerable<T>> childs, Func<T, bool> condition, GraphTraversal mode = GraphTraversal.DepthFirst)
	{
		if (node == null || childs == null || condition == null)
			throw new ArgumentNullException();
		if (mode == GraphTraversal.DepthFirst)
			return node.depthFirstTraversal(childs, condition);
		else
			return node.breadthFirstTraversal(childs, condition);
	}
	private static IEnumerable<T> depthFirstTraversal<T>(this T node, Func<T, IEnumerable<T>> childs, Func<T, bool> condition)
	{
		IEnumerable<T> childrens = childs(node);
		if (childrens == null)
			yield break;
		if (condition(node))
			yield return node;
		foreach (T i in childrens)
		{
			foreach (T j in depthFirstTraversal(i, childs, condition))
			{
				if (condition(j))
					yield return j;
			}
		}
	}
	private static IEnumerable<T> breadthFirstTraversal<T>(this T node, Func<T, IEnumerable<T>> childs, Func<T, bool> condition)
	{
		Queue<T> queue = new Queue<T>();
		queue.Enqueue(node);
		while (queue.Count > 0)
		{
			T currentnode = queue.Dequeue();
			if (condition(currentnode))
				yield return currentnode;
			IEnumerable<T> childrens = childs(currentnode);
			if (childrens != null)
			{
				foreach (T child in childrens)
					queue.Enqueue(child);
			}
		}
	}
	public enum GraphTraversal { DepthFirst, BreadthFirst }
