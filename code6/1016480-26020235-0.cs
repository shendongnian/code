    	public abstract class MyAbstractClass
	{
		protected void DoSomething()
		{
			//use your protected method here 
		}
	}
	public class MyClass : MyAbstractClass
	{
		public MyClass()
		{
			DoSomething();
		}
	}
