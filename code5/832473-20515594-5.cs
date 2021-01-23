	public class ImplemetationA : IInterface1
	{
	    string Bar1{ get; set; }
	    string Bar2{ get; set; }
		
		// some extra definitions here
	}
	
	public class ImplemetationB : IInterface1
	{
	    string Bar1{ get; set; }
	    string Bar2{ get; set; }
		
		// some extra definitions here
	}
	
	public class Problem : Class1<ImplemetationA>
	{
	     public ImplemetationA Foo {get; set;}
	}
