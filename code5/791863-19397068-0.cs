    string input = @"blah blah blah ""keywords"":this is " + Environment.NewLine + "what you want right?, more blah...";
    string pattern = @"""keywords"":(.*),";
    Match match = Regex.Match(input, pattern, RegexOptions.Singleline);
    if (match.Success)
    {
	    string stuff = match.Groups[1].Value;
    }
