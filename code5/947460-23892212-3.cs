	public class Pair<T>
	{
		public T Left { get; set; }
		public T Right { get; set; }
		
		public IntPair(T left, T right)
		{
			this.Left = left;
			this.Right = right;
		}
	}
	
        //or you might want more flexibility
	public class Pair<TLeft, TRight>
	{
		public TLeft Left { get; set; }
		public TRight Right { get; set; }
		
		public IntPair(TLeft left, TRight right)
		{
			this.Left = left;
			this.Right = right;
		}
	}
