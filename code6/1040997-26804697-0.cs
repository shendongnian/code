    //try this :)
    
    using System;
    
    enum Priority
    {
        never,
        killed,
        beauty
    }
    
    class Program
    {
        static void Main()
        {
    	// Write string representation for killed.
    	Priority enum1 = Priority.killed;
    	string value1 = enum1.ToString();
    
    	// Loop through enumerations and write string representations
    	for (Priority enum2 = Priority.never; enum2 <= Priority.beauty; enum2++)
    	{
    	    string value2 = enum2.ToString();
    	    Console.WriteLine(value2);
    	}
        }
    }
    
    Output
    never
    killed
    beauty
