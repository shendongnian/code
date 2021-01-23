    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		DateTime startTime = new DateTime(2014, 1, 1, 1, 5, 1);
    		DateTime endTime = new DateTime(2014, 1, 1, 5, 10, 55);
    		
    		TimeSpan ts = endTime - startTime;
    		
    		Console.WriteLine(ts); // returns "04:05:54"
    	}
    }
