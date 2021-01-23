    private static String EncodeSafeBase64(String toEncode)
	{
		if (toEncode == null)
			throw new ArgumentNullException("toEncode");
		String base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes(toEncode));
		StringBuilder safe = new StringBuilder();
		foreach (Char c in base64String)
		{
			switch (c)
			{
				case '+':
					safe.Append('-');
					break;
				case '/':
					safe.Append('_');
					break;
				default:
					safe.Append(c);
					break;
			}
		}
		return safe.ToString();
	}
	private static String DecodeSafeBase64(String toDecode)
	{
		if (toDecode == null)
			throw new ArgumentNullException("toDecode");
		StringBuilder deSafe = new StringBuilder();
		foreach (Char c in toDecode)
		{
			switch (c)
			{
				case '-':
					deSafe.Append('+');
					break;
				case '_':
					deSafe.Append('/');
					break;
				default:
					deSafe.Append(c);
					break;
			}
		}
		return Encoding.UTF8.GetString(Convert.FromBase64String(deSafe.ToString()));
	}
