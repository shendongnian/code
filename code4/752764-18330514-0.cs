    	static IEnumerable<Folder> Descendants(Folder root)
		{
			var nodes = new Stack<Folder>(new[] { root });
			while (nodes.Any())
			{
				Folder node = nodes.Pop();
				yield return node;
				foreach (var n in node.Children) nodes.Push(n);
			}
		}
