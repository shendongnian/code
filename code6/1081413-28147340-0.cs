    using System;
    class Program
    {
        static void Main()
        {
	        // Taken from my head
        	string simpleTime = "1/1/2000";
        	DateTime time = DateTime.Parse(simpleTime);
        	Console.WriteLine(time);
        	// Taken from HTTP header
        	string httpTime = "Fri, 27 Feb 2009 03:11:21 GMT";
        	time = DateTime.Parse(httpTime);
        	Console.WriteLine(time);
        	// Taken from w3.org
        	string w3Time = "2009/02/26 18:37:58";
        	time = DateTime.Parse(w3Time);
	    	Console.WriteLine(time);
    		// Taken from nytimes.com
    		string nyTime = "Thursday, February 26, 2009";
    		time = DateTime.Parse(nyTime);
    		Console.WriteLine(time);
    		// Taken from this site
    		string perlTime = "February 26, 2009";
    		time = DateTime.Parse(perlTime);
    		Console.WriteLine(time);
    		// Taken from ISO Standard 8601 for Dates
    		string isoTime = "2002-02-10";
    		time = DateTime.Parse(isoTime);
    		Console.WriteLine(time);
    		// Taken from Windows file system Created/Modified
    		string windowsTime = "2/21/2009 10:35 PM";
    		time = DateTime.Parse(windowsTime);
    		Console.WriteLine(time);
    		// Taken from Windows Date and Time panel
    		string windowsPanelTime = "8:04:00 PM";
    		time = DateTime.Parse(windowsPanelTime);
    		Console.WriteLine(time);
        }
    }
