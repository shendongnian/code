    public static bool IsValid(string input)
	{
		string[] tokens = input.Split(',');
		if (tokens.Length > 3)
			return false;
		
		foreach (string token in tokens)
		{
			if (String.IsNullOrWhiteSpace(token))
				return false;
			int val;
			if (!int.TryParse(token, out val))
				return false;
			if (val <= 0 || val > 999)
				return false;
		}
		return true;
	}
