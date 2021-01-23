	public MatchRateLine ParseLine(string line)
	{
		var result = new MatchRateLine();
		
		int fmrPosition = line.IndexOf("FMR: ");
		int fmnrPosition = line.IndexOf("FMNR: ");
		
		string fmrValueString = line.Substring(fmrPosition, fmnrPosition - fmrPosition);
		decimal fmrValue;
		if (decimal.TryParse(fmrValueString, out fmrValue))
		{
			result.FMR = fmrValue;
		}
		
		// repeat for other values
		
		return result;
	}
