    public List<string> ConvertFile()
    {
    	var result = new List<string>();
    	
    	foreach(var line in GetLinesFromFile())
    	{
    		var lineParts = line.Split(';');
    		var fixedLine = line.Replace(";", ";" + lineParts[0] + "|");
    		result.Add(fixedLine);
    	}
    	
    	return result;
    }
