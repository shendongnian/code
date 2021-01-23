	public abstract class A<I1, I2>
		where I1 : A<I1, I2>.InnerOne, new()
		where I2 : A<I1, I2>.InnerTwo, new()
	{
		public InnerOne x;
		public InnerTwo y;
		public A()
		{
			this.x = new I1();
			this.y = new I2();
		}
		public class InnerOne
		{
			public virtual double value()
			{
				return 0;
			}
		}
		public class InnerTwo
		{
			public virtual double value()
			{
				return 0;
			}
		}
	}
