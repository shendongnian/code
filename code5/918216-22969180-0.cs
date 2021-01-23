    using System;
    using System.Text.RegularExpressions;
     
    class Program
    {
        static void Main()
        {
    	// First we see the input string.
    	string input = "Sample File_20140408201420(20140409_0).xlsx";
     
    	// Here we call Regex.Match.
    	Match match = Regex.Match(input, @"Sample File_(.*)\.xlsx",
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
