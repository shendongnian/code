    public class Base
    {
    	public void BaseMethod()
    	{
    	
    	}
    }
    
    public class Sub : Base
    {
    	public void SubMethod()
    	{
    	
    	}
    }
    
    public static class Extensions
    {
    	public static void ExtensionMethod(this Base @base) { }
    }
