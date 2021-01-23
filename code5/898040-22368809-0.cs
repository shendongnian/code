	IEnumerable<string> SplitToLines(string stringToSplit, int maximumLineLength)
	{
		var words = stringToSplit.Split(' ');
		return
			words
				.Skip(1)
				.Aggregate(
					words.Take(1).ToList(),
					(a, w) =>
					{
						var test = a.Last() + " " + w;
						if (test.Length > maximumLineLength)
						{
							a.Add(w);
						}
						else
						{
							a[a.Count() - 1] = test;
						}
						return a;
					});
	}
