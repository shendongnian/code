	public static bool HasPlusBetweenSingleQuotes(string str)
	{
	    bool inSingleQuotes = false;
        char previous = ' '; // just defaulting to a space.
	    foreach (char c in str)
	    {
	        if (c == '\'' && previous != '\\')
	        {
	            inSingleQuotes = !inSingleQuotes;
	        }
            else if (c == '+' && inSingleQuotes)
            {
                return true;
            }
            previous = c;
	    }
	    return false;
	}
