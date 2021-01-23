    //Based on:
    
    //.NET 4.5
    
    //Program that uses Match, Regex: C#
    
    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
    	Regex regex = new Regex(@"([a-zA-Z]+)|([0-9]+)");
    	Match match = regex.Match("ABC123456DEF\n123456\nABC123456\n123456DEF\n");
    	if (match.Success)
    	{
    	    Console.WriteLine(match.Value);
    	}
        }
    }
