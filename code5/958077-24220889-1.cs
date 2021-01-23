    public class Test2
    {
    	int[] myArray = { 1, 2, 3, 4 };
    }
    
    public class MyClass
    {
    	static Test2 instance;  // Only methods of MyClass` will have access to this static instance
    	
    	void foo()
    	{
    		instance.myArray[i] = ...
    	}
    }
