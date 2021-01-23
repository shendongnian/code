    using System;
    
    class Program
    {
        static void Main()
        {
    	//
    	// The constant formatting string.
    	// ... It specifies the padding.
    	// ... A negative number means to left-align.
    	// ... A positive number means to right-align.
    	//
    	const string format = "{0,-10} {1,10}";
    	//
    	// Construct the strings.
    	//
    	string line1 = string.Format(format,
    	    100,
    	    5);
    	string line2 = string.Format(format,
    	    "Carrot",
    	    "Giraffe");
    	//
    	// Write the formatted strings.
    	//
    	Console.WriteLine(line1);
    	Console.WriteLine(line2);
        }
    }
    
    Output
    
    100                 5
    Carrot        Giraffe
