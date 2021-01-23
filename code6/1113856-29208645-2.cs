	public abstract class VeryBaseClass
	{
		public abstract void MyMethod2(string input);
	}
	public class BaseClass : VeryBaseClass
	{
		public override sealed void MyMethod2(string input)
		{
		
		}
	}
	public class DerivedClass : BaseClass
	{
		// Other fields and stuff over there
	}
