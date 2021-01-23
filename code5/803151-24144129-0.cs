   	public static class MyExtensions
	{
		public static IEnumerable<TreeNode>	All( this TreeNodeCollection nodes )
		{
			foreach( TreeNode n in nodes )
			{
				yield return n;
				foreach( TreeNode child in n.Nodes.All( ) )
					yield return child;
			}
		}
	}
