    public Bands()
    {
    	string fileName = @"C:\Users\Lkvideorang\Documents\Visual Studio 2013\Projects\KernRadio\KernRadio\bin\Debug\bands.txt";
    
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
    					bands.Add(new RockBand(lineAra));
    					break;
    				case "JazzCombo":
    					bands.Add(new JazzCombo(lineAra));
    					break;
    				case "SoloAct":
    					bands.Add(new SoloAct(lineAra));
    					break;
    				default:
    					bands.Add(new Band(lineAra));
    					break;
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
