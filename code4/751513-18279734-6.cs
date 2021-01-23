    public class MyClassBuilder
    {
    	public Func<string> x { get; set; }
    	
    	public static implicit operator MyClass(MyClassBuilder builder)
    	{
    		var myClass = new MyClass();
    		
    		if (builder.x != null)
    			myClass.x = builder.x();
    			
    		return myClass;
    	}
    }
