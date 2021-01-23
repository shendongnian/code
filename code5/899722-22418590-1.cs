	public IEnumerable<string> DecodeMorse(string morse)
	{
		var letters =
			map
				.Where(kvp => morse.StartsWith(kvp.Key))
				.Select(kvp => new
				{
					letter = kvp.Value,
					remainder = morse.Substring(kvp.Key.Length)
				})
				.ToArray();
		if (letters.Any())
		{
			var query =
				from l in letters
				from x in DecodeMorse(l.remainder)
				select l.letter + x;
			return query.ToArray();
		}
		else
		{
			return new [] { "" };
		}
	}
