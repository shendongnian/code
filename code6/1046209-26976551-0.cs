    /// <summary>
    /// Count words with Regex.
    /// </summary>
    public static int CountWords1(string s)
    {
    	MatchCollection collection = Regex.Matches(s, @"[\S]+");
    	return collection.Count;
    }
    
    /// <summary>
    /// Count word with loop and character tests.
    /// </summary>
    public static int CountWords2(string s)
    {
    	int c = 0;
    	for (int i = 1; i < s.Length; i++)
    	{
    		if (char.IsWhiteSpace(s[i - 1]) == true)
    		{
    		if (char.IsLetterOrDigit(s[i]) == true ||
    			char.IsPunctuation(s[i]))
    		{
    			c++;
    		}
    		}
    	}
    	if (s.Length > 2)
    	{
    		c++;
    	}
    	return c;
    }
