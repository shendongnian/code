	private static readonly System.Text.RegularExpressions.Regex _orphanEOLChecker =
		new System.Text.RegularExpressions.Regex(@"((?<!\r)\n)|(\r(?!\n))",
				System.Text.RegularExpressions.RegexOptions.Compiled &
				System.Text.RegularExpressions.RegexOptions.Multiline);
	private const string _newLineReplacement = "\r\n";
	private static string FixCarriageReturns(string val)
	{
		if (string.IsNullOrWhiteSpace(val))
			return val;
		return _orphanEOLChecker.Replace(val, _newLineReplacement);
	}
