	public class Node<T> : List<Node<T>>
	{
		public int id { get; set; }
		public Node<T> parent { get; set; }
	
		public bool isRoot
		{
			get { return parent == null; }
		}
	}
