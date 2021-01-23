	public string retrieve(string input)
	{
		var pattern = @"\{.*\}";
		var regex = new Regex(pattern);
		var match = regex.Match(input);
		var content = string.Empty;
		if (match.Success)
		{
			// remove start and end curly brace
			content = match.Value.Substring(1, match.Value.Length - 2);
		}
		return content;
	}
