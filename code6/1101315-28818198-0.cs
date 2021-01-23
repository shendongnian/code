	public static bool HasPlusBetweenSingleQuotes(string str)
	{
	    bool seenSingleQuote = false;
	    foreach (char c in str)
	    {
	        if (c == '\'')
	        {
	            seenSingleQuote = !seenSingleQuote;
	        }
            else if (c == '+' && seenSingleQuote)
            {
                return true;
            }
	    }
	    return false;
	}
