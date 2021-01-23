    using System;
    
    class Program
    {
        static void Main()
        {
    	// A.
    	// The input string.
    	const string s = "ABCDEFGHIJKLM";
    
    	// B.
    	// Test with IndexOf.
    	if (int i = s.IndexOf("E") != -1)
    	{
    	    Console.Write("string contains 'E' at position of "+i);
    	}
    	Console.ReadLine();
        }
    }
