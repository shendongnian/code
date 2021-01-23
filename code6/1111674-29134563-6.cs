    public BandDatabase(MusicianDatabase musicianDatabase)
    {
    	this.musicianDatabase = musicianDatabase;
    
    	string fileName = @"C:\Code\Sandbox\ConsoleApplication1\input.txt";
    
    	string[] allLines;
    
    	try
    	{
    		allLines = File.ReadAllLines(fileName);
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine("Error reading file! Exception: " + ex.Message);
    		return;
    	}
    
    	bands = new List<Band>();
    
    	foreach (var line in allLines)
    	{
    		try
    		{
    			string[] lineAra = line.Split('|');
    
    			if (lineAra.Length < 2) continue;
    
    			switch (lineAra[1])
    			{
    				case "RockBand":
    					bands.Add(CreateRockBand(lineAra));
    					break;
    				// Rest of cases
    			}
    		}
    		catch (Exception ex)
    		{
    			Console.WriteLine("Error parsing line {0}. Exception: {1}", line, ex.Message);
    		}
    	}
    
    	bandsByName = bands.ToList().ToDictionary(x => x.Name, x => x);
    
    	Console.WriteLine("loaded " + bands.Count + " bands");
    }
    private RockBand CreateRockBand(string[] lineAra)
    {
    	Musician vocalist = null;
    	Musician bass = null;
    	Musician drums = null;
    	Musician guitar = null;
    
    	if (lineAra.Length >= 3) 
    		vocalist = musicianDatabase.GetMusicianByName(lineAra[2]);
    
    	if (lineAra.Length >= 4)
    		bass = musicianDatabase.GetMusicianByName(lineAra[3]);
    
    	if (lineAra.Length >= 5)
    		drums = musicianDatabase.GetMusicianByName(lineAra[4]);
    
    	if (lineAra.Length >= 6)
    		guitar = musicianDatabase.GetMusicianByName(lineAra[5]);
    
    	return new RockBand(lineAra, vocalist, bass, drums, guitar);
    }
