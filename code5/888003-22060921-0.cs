    using System;
    
    class Program
    {
        static void Main()
        {
    	// Use DateTime.TryParse when input is valid.
    	string input = "2014-02-02";
    	DateTime dateTime;
    	if (DateTime.TryParse(input, out dateTime))
    	{
    	    Console.WriteLine(dateTime);
    	}
    
    	// Use DateTime.TryParse when input is bad.
    	string badInput = "???";
    	DateTime dateTime2;
    	if (DateTime.TryParse(badInput, out dateTime2))
    	{
    	    Console.WriteLine(dateTime2);
    	}
    	else
    	{
    	    Console.WriteLine("Invalid"); // <-- Control flow goes here
    	}
        }
    }
    
    Output
    
    2/2/2014 12:00:00 AM
    Invalid
