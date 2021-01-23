    String input = @"This is the level $levelnumber of the block $blocknumber.";
	Dictionary<string, string> replacements = new Dictionary<string,string>();
	replacements.Add("$levelnumber", "4");
	replacements.Add("$blocknumber", "2");
	MatchCollection matches = Regex.Matches(input, @"\$\w*");
	for (int i = 0; i < matches.Count; i++)
	{
		string tag = matches[i].Value;
		if (replacements.ContainsKey(tag))
			input = input.Replace(tag, replacements[tag]);
	}
