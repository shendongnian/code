	public partial class PluginControl : ClientTabControlPlugin
	{
		public Foo DoFoo(Bar bar)
		{
			return new Foo(bar);
		}
	}
	public partial class PluginControl(2) : ContactTabControlPlugin
	{
		public Foo DoFoo(Bar bar)
		{	
			return new Foo(bar);
		}
	}
	public class Foo
	{
		public Foo(bar)
		{
			// shared implementation
		}
	}
