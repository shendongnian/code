    public class Foo
    {
    	public string Bar { get; set; }
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		var foo  = new Foo { Bar = "bar" };
    		Console.WriteLine("Before: {0}", foo.Bar);
    		ChangeBar(foo);
    		Console.WriteLine("After: {0}", foo.Bar);
    		ChangeBarReference(foo);
    		Console.WriteLine("After reference: {0}", foo.Bar);		
    	}
    	
    	private static void ChangeBar(Foo foo)
    	{
    		foo.Bar = "baz";
    	}
    	
    	private static void ChangeBarReference(Foo foo)
    	{
    		foo = new Foo { Bar = "qux" };
    	}
    }
