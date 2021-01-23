    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{		
    		var x = new List<String>();
    		x.Add("Hello");
    		x.Add("Hola");
    		x.Add("Aloha");
    		
    		var y = new List<String>();
    		y.Add("Goodbye");
    		y.Add("Adios");
    		y.Add("Aloha");
    		
    		var intersects = x.Intersect(y);
    		intersects.ToList().ForEach(zz=> Console.WriteLine(zz));
    		
    	}
    }
