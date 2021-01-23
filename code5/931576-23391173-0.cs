    using System;
    using System.Collections.Generic;
    
    public class Test
    {
    	public static void Main()
    	{
    		string[] items = {"10", "1", "30", "-5"};
    		Array.Sort(items, (x, y) => 
    		{
    			int xNum = int.Parse(x);
    			int yNum = int.Parse(y);
    			return Comparer<int>.Default.Compare(xNum, yNum);
    		});
    		
    		foreach(var item in items)
    			Console.WriteLine(item);
    	}
    }
