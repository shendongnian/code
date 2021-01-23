	public static IEnumerable<string> GetValues(string input)
	{
        // Suppose regex could be any regex
		var regex = new Regex(@"(?:(?<concat>\d+),?)+");
		foreach (Match match in regex.Matches(input))
		{
            // Does this regex have our special feature?
			if (regex.GroupNumberFromName("concat") >= 0)
			{
                // Concat the captured values
			    var captures = match.Groups["concat"].Captures.Cast<Capture>().Select(c => c.Value).ToArray();
			    yield return String.Concat(captures);
			}
			else
			{
                // This is a normal regex
				yield return match.Value;	
			}
		}
	}
