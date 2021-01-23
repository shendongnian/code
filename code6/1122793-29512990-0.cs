    using System;
        
    class Program
    {
        static void Main()
        {
    	    DateTime now = DateTime.Now;
    	    //
    	    // Write the month integer and then the three-letter month.
    	    //
    	    Console.WriteLine(now.Month); //outputs 5
    	    Console.WriteLine(now.ToString("MMM")); //outputs May
        }
    }
