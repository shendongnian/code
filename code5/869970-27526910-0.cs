    /// <summary>
    /// Gets the char from unicode hexadecimal string.
    /// </summary>
    /// <param name="characterCode">The character code e.g. '\x2800'.</param>
    /// <returns>the current available unicode character if available e.g. ' '</returns>
    public static string GetCharFromUnicodeHex(String characterCode)
    {
    
    	if (!String.IsNullOrEmpty(characterCode))
    	{
    		if (characterCode.StartsWith(@"\"))
    		{
    			characterCode = characterCode.Substring(1);
    		}
    		if (characterCode.StartsWith("x"))
    		{
    			characterCode = characterCode.Substring(1);
    		}
    
    		int number;
    		bool success = Int32.TryParse(characterCode, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture, out number);
    
    		if (success)
    		{
    			return GetCharFromUnicodeInt(number);
    		}
    	}
    	return String.Empty;
    }
    
    
    /// <summary>
    /// try to parse a char from unicode int.
    /// </summary>
    /// <param name="number">The number code e.g. 10241.</param>
    /// <returns>the char of the given value e.g. ' '</returns>
    public static string GetCharFromUnicodeInt(int number)
    {
    	try
    	{
    		char c2 = (char)number;
    		return c2.ToString();
    	}
    	catch { }
    	return String.Empty;
    }
