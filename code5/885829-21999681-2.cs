	static string Convert(int value)
	{
		// use a Dictionary instead of F# Map
		var m = new Dictionary<char, char>
		{
			{'0', 'O'},
			{'1', '1'},
			{'8', 'B'}
		};
		
		// Convert to IEnumerable<char> directly from dictionary
		var valStrs = value.ToString().Select(c => m[c]);
		// Build results from characters
		return new String(valStrs.Reverse().ToArray());
	}
