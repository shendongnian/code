    using System;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		Regex regex = new Regex(@"\d{4}");
    	    Match match = regex.Match("Payment for the month ending 30 Nov 2014");
    	    if (match.Success)
    	    {
    	        Console.WriteLine(match.Value);
    	    }
    	}
    }
