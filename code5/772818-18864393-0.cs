    using System;
    using System.IO;
    
    class Program
    {
        static void Main()
        {
    	//
    	// Move a file found on the C:\ volume.
    	// If the file is not found (SAM.txt doesn't exist),
    	// then you will get an exception.
    	//
    	try
    	{
    	    File.Move(@"C:\SAM.txt", @"C:\SAMUEL.txt"); // Try to move
    	   
    	}
    	catch (IOException ex)
    	{
    	   
    	}
        }
    }
