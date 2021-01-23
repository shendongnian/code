    public interface MyInterface
    {
    	public int id { get; }
    }
    
    class MyClass : MyInterface
    {
    	public int id { get; private set; }
    	
    	public MyClass()
    	{
    		id = 2;
    	}
    }
