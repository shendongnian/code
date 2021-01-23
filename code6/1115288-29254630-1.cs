	public class B: A<B.InnerOne, B.InnerTwo>
	{
		public B():base(){ }
		public class InnerOne: A<InnerOne, InnerTwo>.InnerOne
		{
			public override double value()
			{
				return 100;
			}
		}
		public class InnerTwo: A<InnerOne, InnerTwo>.InnerTwo
		{
			public override double value()
			{
				return 100;
			}
		}
	}
