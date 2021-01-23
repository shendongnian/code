    using System;
    using System.Collections.Generic;
    using System.IO;
    
    class Program
    {
        static void Main()
        {
    	const string f = "TextFile1.txt";
    
    	// 1
    	// Declare new List.
    	List<string> lines = new List<string>();
    
    	// 2
    	// Use using StreamReader for disposing.
    	using (StreamReader r = new StreamReader(f))
    	{
    	    // 3
    	    // Use while != null pattern for loop
    	    string line;
    	    while ((line = r.ReadLine()) != null)
    	    {
    		// 4
    		// Insert logic here.
    		// ...
    		// "line" is a line in the file. Add it to our List.
    		lines.Add(line);
    	    }
    	}
    
    	// 5
    	// Print out all the lines.
    	foreach (string s in lines)
    	{
    	    Console.WriteLine(s);
    	}
        }
    }
    
    Output
        (Prints contents of TextFile1.txt)
    
    This is a text file I created,
    Just for this article.
