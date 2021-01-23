    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
   		    string[] products= { "10.5","20.5","50.5"};
    		foreach (var product in products)
          	{
    		     Console.WriteLine(Convert.ToDouble(product));
    		}    		
    	}
    }
