    using System;
    using System.Linq.Expressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Expression<Func<string, string>> func = (x) => DoSomething(x);
    		
    		Console.WriteLine(func.ToString());
    	}
    	
    	public static string DoSomething(string s)
    	{
    		return s; // just as sample
    	}
    }
