    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Test t = new Test() //will give you compile time error.
    	    Test t1 = new Test(""); //should work fine.
    		
    	}
    }
    
    public class Test
    {
    	public Test(string a)
    	{
    	}
    }
