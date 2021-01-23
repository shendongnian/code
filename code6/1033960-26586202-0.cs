    void Main()
    {
    	var location = @"D:\text.txt";
        if (System.IO.File.Exists(location) == true)
        {
            using (StreamReader reader = new StreamReader(location))
            {
    			const int linesToRead = 3;
    			while(!reader.EndOfStream)
    			{
    				string[] currReadLines = new string[linesToRead];
    				for (var i = 0; i < linesToRead; i++)
    				{
    					var currLine = reader.ReadLine();
    					if (currLine == null)
    						break;
    
    					currReadLines[i] = currLine;
    				}
    				
    				//Do your work with the three lines here
    				//Note; Partial records will be persisted
    				//var userName = currReadLines[0] ... etc...
    			}
    		}
    	}
    }
