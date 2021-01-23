    public class Foo
    {
	    public Bar Property { get; set; }
    }
    public abstract class Bar
    {
	    public sealed class Something : Bar
	    {
	
	    }
	
	    public sealed class SomethingElse : Bar
	    {
	
	    }
	    public sealed class Whatever: Bar
	    {
	
	    }	    
    }
