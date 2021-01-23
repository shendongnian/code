	public static void ReverseString(string str)
	{
		if(str.Length > 0)
		{
			char ch = str[0];
			ReverseString(str.Substring(1));
			Console.Write(ch);
		}
	}
