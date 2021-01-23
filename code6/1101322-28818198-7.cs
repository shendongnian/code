	public static IEnumerable<int> PlusBetweenSingleQuotesIndexes(string str)
	{
	    bool inSingleQuotes = false;
        for(int i=0;i<str.Length;i++)
	    {
	        if (str[i] == '\'')
	        {
	            inSingleQuotes = !inSingleQuotes;
	        }
            else if (str[i] == '+' && inSingleQuotes)
            {
                yield return i;
            }
	    }
	}
