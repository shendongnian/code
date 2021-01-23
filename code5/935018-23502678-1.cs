    public int[] CharPositions(string input, char match)
    {
    	return Regex.Matches(input, Regex.Escape(match.ToString()))
    	           .Cast<Match>()
    			   .Select(m => m.Index)
    			   .ToArray();
    }
