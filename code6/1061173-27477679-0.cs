	var query =
		list
			.Skip(1)
			.Aggregate(new
			{
				results = list.Take(1).ToList(),
				last = list.First()
			}, (a, x) =>
			{
				if (x > a.last + 1)
				{
					a.results.Add(x);
				}
				return new { a.results, last = x };
			}).results;
