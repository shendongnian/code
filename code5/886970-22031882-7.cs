    for (int i = 0; i < 3; i++)
    {
        try
    	{
    	Console.WriteLine("Outer loop start");
    	foreach (int l in new int[] {1,2,3})
    	{		
    	    Console.WriteLine("Inner loop start");
    		try
    		{
    			Console.WriteLine(l);
    			 throw new Exception("e");
    		}
    		catch
    		{
    			Console.WriteLine("In inner catch about to continue");
    			continue;
    		}			
    		Console.WriteLine("Inner loop ends after catch");
    		
    	}
    	Console.WriteLine("Outer loop end");
    	}
    	catch
        {
    	    Console.WriteLine("In outer catch");
    	}
    }
