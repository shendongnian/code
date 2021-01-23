	public abstract class MyAbstractClass
	{
		//This one HAS to be defined in the inheritor class, like an interface
		public abstract void DoSomeOtherThing();
        //This is your function that can only be called by objects that inherit from this class.
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
		public override void DoSomeOtherThing()
		{
		}
	}
