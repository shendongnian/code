    static void PrintBandDetails()
    {
    	Console.Write("Enter a band name: ");
    	string bandName = Console.ReadLine();
    	
    	var band = bands.GetBand(bandName);
    	
    	if (band == null)
    	{
    		Console.WriteLine("Invalid band name")
    		return;
    	}
    
    	Console.WriteLine("Guitarist was " + band.guitar);
    	// etc.
    	
    	var tunes = tunes.GetByBand(bandName);
    	
    	Console.WriteLine("Tunes:");
    	
    	foreach(var t in tunes)
    		Console.WriteLine(t);
    }
