	var query =
		_keylist
			.SelectMany(k => dictionary[k])
			.Aggregate(
				new Dictionary<int, int>(),
				(d, v) =>
				{
					if (d.ContainsKey(v))
					{
						d[v] += 1;
					}
					else
					{
						d[v] = 1;
					}
					return d;
				})
		.OrderByDescending(kvp => kvp.Value)
		.Select(kvp => new
		{
			key = kvp.Key,
			count = kvp.Value,
		});
