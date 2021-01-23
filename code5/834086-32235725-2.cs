    foreach(string loop1 in File.ReadLines("data.txt"))
    {
    	if (String.IsNullOrEmpty(line)) 
    	{
    		continue;
    	}
    	if (line.Equals("end"))
    	{
    		//do stuff
    	}
    	string[] parts = line.Split(" ");
    	if (parts.Length != 2) 
    	{
    		//do stuff
    	}
    	switch(line[0])
    	{
    		case "one":
    			if (!line[1].Equals("1"))
    			{
    				Console.WriteLine("ERROR! One != 1");
    			}
    			break;
    		case "two":
    			....
    		default:
    			//not recognized. Do stuff
    			break;
    	}
    }
