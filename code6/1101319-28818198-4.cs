	public static bool HasPlusBetweenSingleQuotes(string str)
	{
	    bool inSingleQuotes = false;
	    foreach (char c in str)
	    {
	        if (c == '\'')
	        {
	            inSingleQuotes = !inSingleQuotes;
	        }
            else if (c == '+' && inSingleQuotes)
            {
                return true;
            }
	    }
	    return false;
	}
