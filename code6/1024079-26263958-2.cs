    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var numbers = new[] { 1, 1, 5, 1, 1};
    		
    		var result = Array.IndexOf(numbers, 5);
    	
    	    Console.WriteLine(result);
    	}
    }
