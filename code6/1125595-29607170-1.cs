    public class MyObject
    {
    	public void Foo()
    	{
    	}
    	
    	public void MethodToCallAfterUse()
    	{
    		// Something they want to call after the use of an instance of MyObject
    	}
    }
    
    var myObj = new MyObject(); 
    try
    {
    	myObj.Foo();
    }
    finally
    {
    	myObj.MethodToCallAfterUse();
    }
