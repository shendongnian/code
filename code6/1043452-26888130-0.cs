	public static IEnumerable<string> SplitOnType(string str)
	{
		StringBuilder builder = new StringBuilder();
		int previousType = -1;
		foreach (char c in str)
		{
			int type;
			if ('a' <= c && c <= 'z')
				type = 0;
			else if ('A' <= c && c <= 'Z')
				type = 1;
			else if ('0' <= c && c <= '9')
				type = 2;
			else
				type = 3;
			if (previousType != -1 && type != previousType)
			{
				yield return builder.ToString();
				builder.Clear();
			}
					
			builder.Append(c);
			previousType = type;
		}
		if (builder.Length > 0)
			yield return builder.ToString();
	}
