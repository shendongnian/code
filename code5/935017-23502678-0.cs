    public int[] CharPositions(string input, char match)
    {
    	return Regex.Matches(input, match.ToString())
    	           .Cast<Match>()
    			   .Select(m => m.Index)
    			   .ToArray();
    }
