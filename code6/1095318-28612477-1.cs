	public static string CapitalizeFirstLetter(this string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return input;
		}
		return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1);
	}
