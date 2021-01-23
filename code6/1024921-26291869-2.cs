	Func<int, IEnumerable<char>> getReversedNumerals = null;
	getReversedNumerals = n =>
	{
		IEnumerable<char> results =
			new [] { i2n[n % 12], };
		var n2 = n / 12;
		if (n2 > 0)
		{
			results = results.Concat(getReversedNumerals(n2));
		}
		return results;
	};
	
	Func<IEnumerable<char>, int, int> processReversedNumerals = null;
	processReversedNumerals = (cs, x) =>
		cs.Any()
			? x * n2i[cs.First()]
				+ processReversedNumerals(cs.Skip(1), x * 12)
			: 0;
