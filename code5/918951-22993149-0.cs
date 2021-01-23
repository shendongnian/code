    private static bool ContainsNonAlphanumeric(string s)
	{
		Regex pattern = new Regex(@"\W|_");
		if(pattern.IsMatch(s))
		{
			return true;
		}
		return false;
	}
