	public class Tree<T>
	{
		public T Value { get; private set; }
		public IEnumerable<Tree<T>> Children { get; private set; }
		
		public Tree(T value, IEnumerable<Tree<T>> children)
		{
			this.Value = value;
			this.Children = new List<Tree<T>>(children);
		}
		public string Dump()
		{
			return this.Dump(0);
		}
		
		protected string Dump(int level)
		{
			var query =
				(new [] { "".PadLeft(level, '-') + this.Value.ToString() })
				.Concat(this.Children.Select(x => x.Dump(level + 1)));
	
			return String.Join(System.Environment.NewLine, query);
		}
	}
