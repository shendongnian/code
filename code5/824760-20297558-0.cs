    using System;
    
    class Program
    {
        static void Main()
        {
    	try
    	{
    	    // Acquire random integer for use in control flow.
    	    // ... If the number is 0, an error occurs.
    	    // ... If 1, the method returns.
    	    // ... Otherwise, fall through to end.
    	    int random = new Random().Next(0, 3); // 0, 1, 2
    	    if (random == 0)
    	    {
    		throw new Exception("Random = 0");
    	    }
    	    if (random == 1)
    	    {
    		Console.WriteLine("Random = 1");
    		return;
    	    }
    	    Console.WriteLine("Random = 2");
    	}
    	finally
    	{
    	    // This statement is executed before the Main method is exited.
    	    // ... It is reached when an exception is thrown.
    	    // ... It is reached after the return.
    	    // ... It is reached in other cases.
    	    Console.WriteLine("Control flow reaches finally");
    	}
        }
    }
