    using System;
    using System.Net;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string myval = "put a number / your value here";
    		decimal d = 0;
    		var result = decimal.TryParse(myval, out d);
    		Console.WriteLine(result);	
    		Console.WriteLine(d);
    	}
    }
