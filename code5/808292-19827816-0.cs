    using System;
    using System.Linq;
    
    public class Test
    {
    	public static void Main()
    	{
    		var infiniteIterator =
    		    Enumerable.Range(Int32.MinValue, Int32.MaxValue)
    		              .SelectMany(i => Enumerable.Range(Int32.MinValue, Int32.MaxValue))
        		          .SelectMany(i => Enumerable.Range(Int32.MinValue, Int32.MaxValue))
    		              .SelectMany(i => Enumerable.Range(Int32.MinValue, Int32.MaxValue))
    		              .Select(i => default(int));
    		
    		foreach (var infinite in infiniteIterator)
    		    Console.WriteLine(infinite);
    	}
    }
