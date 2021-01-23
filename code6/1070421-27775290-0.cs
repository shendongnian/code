    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var x = new string[]
    		{
    			"asd",
    			"asd",
    			"Asdad"
    		};
    		
    		var i = x.Select(c => c.ToUpper()).Distinct().Count();
    		
    		Console.WriteLine(i);
    	}
    }
