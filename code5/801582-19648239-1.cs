    public class MyClass // this is the declaration of the class 
    {
    	// this is a property, it is accessible by things outside of this class.
    	public static string MyProperty { get; set; } ;
    	private static string _myField; // this is a ['private] field, it is intended to store the state of the object. it cannot be accessed from outside of this class
    
    	static void Main(string[] args)
    	{
    		// this is the method that gets run first so it make all of your initial calls
    	}
    	
    	public static void TestIfElse(int n)
    	{
    		// this is another method (taught as module, operation, action, or subroutine in schools)
    		// it has return type of void which is more or less "nothing". This type of behavior simply does 
    		// something but doesn't return a value
    	}
    	
    	public static bool IsNotPrime(int input)
    	{
    		// this is an actual function in that will return a single value whether its a primitive value or an
    		// object. Whatever it is, there's ONE. The point is that a call to this function is now synonymous with
    		// the value it returns. So for example, if this method was real, it is equivalent to 'true' so you could 
    		// actually say if(IsNotPrime(8)){ // do things }
    		return input % 2 == 0;
    	}
    }
