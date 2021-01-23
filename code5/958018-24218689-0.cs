    public static string Hex2String(string input)
	{
		var builder = new StringBuilder();
		for(int i = 0; i < input.Length; i+=2){ //throws an exception if not properly formatted
			string hexdec = input.Substring(i, 2);
			int number = Int32.Parse(hexdec, NumberStyles.HexNumber);
			char charToAdd = (char)number;
			builder.Append(charToAdd);
		}
		return builder.ToString();
	}
