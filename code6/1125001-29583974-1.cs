	public List<string> ReadAllLines(StreamReader sr)
	{
		List<string> allLines = new List<string>();
		string line; 
		while ((line = sr.ReadLine()) != null) 
		{
			allLines.Add(line);
		}
		return allLines;
	}
	
