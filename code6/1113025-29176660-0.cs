    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Test
    {
    	private static Dictionary<string, string> fruitLookup = 
            new Dictionary<string, string>
    	{
    		{"blueberry", "blueberries"},
    		{"peach", "peaches"},
    		{"apple", "apples"}
    	};
    	
    	public static void Main()
    	{
    		var fruitList = new List<string> {"blueberry", "peach", "apple"};
            // Here is your one-line conversion:
    		var plurals = fruitList.Select(f => fruitLookup[f]).ToList();
    		
    		foreach (var p in plurals)
    		{
    			Console.WriteLine(p);
    		}
    	}
    }
