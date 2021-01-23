	public class Base
	{
		public string Something { get; private set; }
	}
	public class Derived : Base { }
	public class MiscTest
	{
		static void Main( string[] args )
		{
			var property1 = typeof( Derived ).GetProperty( "Something" );
			var setter1 = property1.SetMethod; //null
			var property2 = typeof( Base ).GetProperty( "Something" );
			var setter2 = property2.SetMethod; //non-null
			bool test1 = property1 == property2; //false
			bool test2 = property1.DeclaringType == property2.DeclaringType; //true
			var solution = property1.DeclaringType.GetProperty( property1.Name );
			var setter3 = solution.SetMethod; //non-null
			bool test3 = setter3 == setter1; //false
			bool test4 = setter3 == setter2; //true
		}
	}
