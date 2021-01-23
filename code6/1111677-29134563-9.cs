    static void PrintBandDetails()
    {
    	Console.Write("Enter a band name: ");
    	string bandName = Console.ReadLine();
    	
    	var band = bandDatabase.GetBand(bandName);
    	
    	if (band == null)
    	{
    		Console.WriteLine("Invalid band name")
    		return;
    	}
    
    	Console.WriteLine("Guitarist was " + band.GuitarPlayer);
    	// etc.
    	
    	var tunes = tuneDatabase.GetByBand(bandName);
    	
    	Console.WriteLine("Tunes:");
    	
    	foreach(var t in tunes)
    		Console.WriteLine(t);
    }
