	static byte[] RemoveJunk(byte[] input)
	{
		var end = Array.IndexOf(input, (byte)0);
		Console.WriteLine(end);
		if (end < 0)
			return input;
		var result = new byte[end];
		Array.Copy(input, result, end);
		return result;
	}
