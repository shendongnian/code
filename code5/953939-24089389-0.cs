    public static class Extensions
    {
    	public static string ICD9Format(this string input)
    	{
    		//check easy cases first
    		if (string.IsNullOrEmpty(input) || input.Length <= 3)
    		{
    			return input;
    		}
    		
    		return input.Insert(3, ".");
    	}
    }
