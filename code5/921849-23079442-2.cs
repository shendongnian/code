    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
    	// First we see the input string.
    	string input = "<area href='#' title='name' shape='poly' coords='38,23,242'/>";
    
    	// Here we call Regex.Match.
    	Match match = Regex.Match(input, @"title='(\w+)'",
    	    RegexOptions.IgnoreCase);
    
    	// Here we check the Match instance.
    	if (match.Success)
    	{
    	    // Finally, we get the Group value and display it.
    	    string key = match.Groups[1].Value;
    	    Console.WriteLine(key);
    	}
        }
    }
