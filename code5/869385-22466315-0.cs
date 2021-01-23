    string PossibleString = PossibleString.ToString().ToLower();
    string StaticText = StaticText.ToLower();
    decimal PossibleStringLength = (PossibleString.Length);
    decimal StaticTextLength = (StaticText.Length);
    decimal NumberOfErrorsAllowed = Math.Round((StaticTextLength * (ErrorAllowance / 100)), MidpointRounding.AwayFromZero);
    int LevenshteinDistance = LevenshteinAlgorithm(StaticText, PossibleString);
    string PossibleResult = string.Empty;
    
    if (LevenshteinDistance == PossibleStringLength - StaticTextLength)
    {
    	// Perfect match. no need to calculate.
    	PossibleResult = StaticText;
    }
    else
    {
    	int TextLengthBuffer = (int)StaticTextLength - 1;
    	int LowestLevenshteinNumber = 999999;
    
    	for (int i = 0; i < 3; i++) // Check for best results with same amount of characters as expected, as well as +/- 1
    	{
    		for (int e = TextLengthBuffer; e <= (int)PossibleStringLength; e++)
    		{
    			string possibleResult = (PossibleString.Substring((e - TextLengthBuffer), TextLengthBuffer));
    			int lAllowance = (int)(Math.Round((possibleResult.Length - StaticTextLength) + (NumberOfErrorsAllowed), MidpointRounding.AwayFromZero));
    			int lNumber = LevenshteinAlgorithm(StaticText, possibleResult);
    
    			if (lNumber <= lAllowance && ((lNumber < LowestLevenshteinNumber) || (TextLengthBuffer == StaticText.Length && lNumber <= LowestLevenshteinNumber)))
    			{
    				PossibleResult = possibleResult;
    				LowestLevenshteinNumber = lNumber;
    			}
    		}
    		TextLengthBuffer++;
    	}
    }
    
    
    public static int LevenshteinAlgorithm(string s, string t)
    {
    	int n = s.Length;
    	int m = t.Length;
    	int[,] d = new int[n + 1, m + 1];
    
    	if (n == 0)
    	{
    		return m;
    	}
    
    	if (m == 0)
    	{
    		return n;
    	}
    
    	for (int i = 0; i <= n; d[i, 0] = i++)
    	{
    	}
    
    	for (int j = 0; j <= m; d[0, j] = j++)
    	{
    	}
    
    	for (int i = 1; i <= n; i++)
    	{
    		for (int j = 1; j <= m; j++)
    		{
    			int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
    
    			d[i, j] = Math.Min(
    				Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
    				d[i - 1, j - 1] + cost);
    		}
    	}
    	return d[n, m];
    }
