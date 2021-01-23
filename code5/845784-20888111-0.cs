	public static bool ValidateDateFormat(string format, IFormatProvider provider)
	{
		try
		{
			DateTime.Now.ToString(format, provider);
			return true;
		}
		catch(FormatException)
		{
			return false;
		}
	}
