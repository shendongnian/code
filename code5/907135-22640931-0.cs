    using System;
    
    public class A
    {
    	private int i;
    	public int I { get { return i; } }
    	public A(int i) { this.i = i; }
    	public static implicit operator bool(A a) { return a.i != 0; }
    }
    
    public class Test
    {
    	public static void Main()
    	{
    		A a1 = new A(0);
    		if (a1) 
    		  Console.WriteLine("a1 is true");
    		else
    		  Console.WriteLine("a1 is false");
    
    		A a2 = new A(42);
    		if (a2) 
    		  Console.WriteLine("a2 is true");
    		else
    		  Console.WriteLine("a2 is false");
    	}
    }
