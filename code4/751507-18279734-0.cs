    public class MyClass
    {
       public string x { get; private set; }
    
       public MyClass(Func<string> x = null)
    	{
    		if (x != null)
    			this.x = x();
    	}
    }
