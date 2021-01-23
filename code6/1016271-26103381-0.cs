    using System;
    using System.Collections.Generic;
    using System.Linq;
					
    public class Program
    {
	    public static void Main()
    	{
		    IList<int> l = new List<int>();
    		for(int i = 0; i < 5000; i++){
    			l.Add(i);	
    		}
		
    		var a = l.Take(1000); //First 1000 items
    		var b = l.Skip(1000).Take(1000); //Second 1000 items
    		var c = l.Skip(2000); //Final 3000 items
		
    		System.Console.WriteLine("a: " + a.Count());
    		System.Console.WriteLine("b: " + b.Count());
    		System.Console.WriteLine("c: " + c.Count());
	    }
    }
