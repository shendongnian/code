    public class MyObject : IDisposable
    {
    	public void Foo()
    	{
    	}
    	
    	public void Dispose()
    	{
    		// Something they want to call after the use of an instance of MyObject
    	}
    }
    ...
    using (var myObj = new MyObject())
    {
    	myObj.Foo();
    }
