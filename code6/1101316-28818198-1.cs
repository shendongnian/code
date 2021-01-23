	public static IEnumerable<int> PlusBetweenSingleQuotesIndexes(string str)
	{
	    bool seenSingleQuote = false;
        for(int i=0;i<str.Length;i++)
	    {
	        if (str[i] == '\'')
	        {
	            seenSingleQuote = !seenSingleQuote;
	        }
            else if (str[i] == '+' && seenSingleQuote)
            {
                yield return i;
            }
	    }
	}
