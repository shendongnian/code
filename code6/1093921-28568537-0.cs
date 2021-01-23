    public abstract class A 
    {
    	public A(string x) 
    	{
    	}
    }
    
    public class B : A 
    {
        // If you don't add ": base(x)" 
        // your code won't compile, because A has a 
        // constructor with parameters!
    	public B(string x) : base(x)
    	{
    	}
    }
