	public class ServiceBase
	{
		public Foo MethodA()
		{
		    // Shared implementation
		}
		
		public abstract Foo MethodB();
	}
	public class ServiceA : ServiceBase
	{
		public override Foo MethodB()
		{
		    // ServiceA-specific implementation
		}
		
		public Foo MethodC()
		{
		    // Only in ServiceA
		}
	}
	public class ServiceB : ServiceBase
	{
		public override Foo MethodB()
		{
		    // ServiceA-specific implementation
		}
	}
