	public class CountVisitor<T> : MyVisitor<T>
	{
		public int count { get; set;}
		
		public CountVisitor()
		{
			count = 0;
		}
		
		public void Visit(TreeStructure<T> tree)
		{
			count++;
		}
	}
