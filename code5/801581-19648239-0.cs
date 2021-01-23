    public class MyClass // this is the declaration of the class 
    {
    	// this is a property, it is accessible by things outside of this class.
    	public static string MyProperty { get; set; } ;
    	private static string _myField; // this is a ['private] field, it is intended to store the state of the object. it cannot be accessed from outside of this class
    
    	static void Main(string[] args)
    	{
    		// this is the method/function that gets run first so it makes all of your initial calls that get your program rolling
    	}
    	
    	public static void TestIfElse(int n)
    	{
    		// this is another method/function
    	}
    }
