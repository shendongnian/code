	var input = new List<string>()
	{
		"Customers\\Order1",
		"Customers\\Order1\\Product10",
		"Customers\\Order1\\Product1",
		"Customers\\Order2\\Product1",
		"Customers\\Order2\\Product1\\Price",
	};
	
	var paths = input.ToDictionary(x => x, x => x.Split('\\'));
	
	var query =
		from x in input
		where !input
			.Any(y => y.Length > x.Length
				&& paths[x]
					.Zip(paths[y], (p1, p2) => new { p1, p2 })
					.All(p => p.p1 == p.p2))
		select x;
	
	var result = query.ToList();
