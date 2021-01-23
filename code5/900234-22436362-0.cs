    public static bool ContainsOneDigit(string s)
	{
		if (String.IsNullOrWhiteSpace(s) || s.Length != 8)
			return false;
		int nb = 0;
		foreach (char c in s)
  		{
			if (!Char.IsLetterOrDigit(c))
				return false;
    		if (c >= '0' && c <= '9') // just thought, I could use Char.IsDigit() here ...
      			nb++;
  		}
		return nb == 1;
	}
