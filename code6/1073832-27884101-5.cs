    public class Base
    {
    	protected void BaseMethod()
    	{
    		this.ExtensionMethod();
    	}
    }
    
    public class Sub : Base
    {
    	public void SubMethod()
    	{
    		// What comes here?
    	}
    }
    
    public static class Extensions
    {
    	public static void ExtensionMethod(this Base @base) 
    	{ 
    		Console.WriteLine ("base");
    	}
    	
    	public static void ExtensionMethod(this Sub sub) 
    	{
    		Console.WriteLine ("sub");
    	}
    }
