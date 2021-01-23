	public List<MatchRateLine> ParseFile(string filename)
	{
		var result = new List<MatchRateLine>();
		
		using (var reader = new StreamReader(filename))
		{
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				result.Add(ParseLine(line));
			}
		}
		
		return result;
	}
	
