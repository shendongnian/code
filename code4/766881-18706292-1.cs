	public static void ReverseString(string str)
	{
		if(!String.IsNullOrEmpty(str))
		{
			char ch = str[0];
			ReverseString(str.Substring(1));
			Console.Write(ch);
		}
	}
