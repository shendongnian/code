	bool IsSequentiallyIncreasing(string input)
	{
		char? lastDigit = null;
		foreach (char c in input)
		{
			if (!c.IsDigit || (lastDigit != null && c != lastDigit + 1))
			{
				return false;
			}
			
			lastDigit = c;
		}
		return true;
	}
