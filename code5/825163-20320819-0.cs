	public class Tree<T> : List<Tree<T>>
	{
		public Tree(T value, IEnumerable<Tree<T>> children)
			: base(children)
		{
			this.Value = value;
		}
		public T Value { get; set; }
	}
