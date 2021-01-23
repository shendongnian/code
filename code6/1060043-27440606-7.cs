	private static string Escape( string s )
	{
		var replacements = new Dictionary<string, string>() { {@"\", @"\5C"},
															  {@"*", @"\2A"},
															  {@"(", @"\2B"},
															  {@")", @"\29"},
															  {@"/", @"\3C"}};
		string ret = s;
		//escape the chars that need to be escaped
		foreach (var pair in replacements)
		{
			ret = ret.Replace(pair.Key, pair.Value);
		}
		var whiteSpaceEscapeChars = @"\";
		//escape leading white space
		int whiteSpaceCount = 0;
		while (whiteSpaceCount < ret.Count() && Char.IsWhiteSpace(ret[whiteSpaceCount]))
		{
			ret = String.Format("{0}{1}{2}", ret.Substring(0, whiteSpaceCount), whiteSpaceEscapeChars,
				ret.Substring(whiteSpaceCount));
			whiteSpaceCount += 1 + whiteSpaceEscapeChars.Length;
		}
		//escape trailing whitespace
		if (whiteSpaceCount < ret.Count())
		{
			whiteSpaceCount = ret.Count() -1;
			while (whiteSpaceCount >= 0 && Char.IsWhiteSpace(ret[whiteSpaceCount]))
			{
				ret = String.Format("{0}{1}{2}", ret.Substring(0, whiteSpaceCount), whiteSpaceEscapeChars,
					ret.Substring(whiteSpaceCount));
				whiteSpaceCount--;
			}
		}
		return ret;
	}
