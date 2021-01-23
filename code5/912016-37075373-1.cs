	public bool IsNumeric(string value)
	{
		bool isNumeric = true;
		char[] digits = "0123456789".ToCharArray();
		char[] letters = value.ToCharArray();
		for (int k = 0; k < letters.Length; k++)
		{
			for (int i = 0; i < digits.Length; i++)
			{
				if (letters[k] != digits[i])
				{
					isNumeric = false;
					break;
				}
			}
		}
		return isNumeric;
	}
