	static string Convert(int value)
	{
		var m = new Dictionary<char, char>
		{
			{'0', 'O'},
			{'1', '1'},
			{'8', 'B'}
		};
		
		var valStrs = value
			.ToString()
			.Reverse()
			.Select(c => m[c])
			.Aggregate(new List<char>(), (list, val) => { list.Add(val); return list;});
		return new String(valStrs.ToArray());
	}
