	public static string UTF8From1252(string source)
	{
		// get original UTF-8 bytes from CP1252-encoded string
		byte[] bytes = System.Text.Encoding.GetEncoding("windows-1252").GetBytes(source);
		return System.Text.Encoding.UTF8.GetString(bytes);
	}
