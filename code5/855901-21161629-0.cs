	var results =
		listOfInt
			.Skip(1)
			.Aggregate(
				new List<List<int>>(new [] { listOfInt.Take(1).ToList() }),
				(a, x) =>
				{
					if (a.Last().Last() + 1 == x)
					{
						a.Last().Add(x);
					}
					else
					{
						a.Add(new List<int>(new [] { x }));
					}
					return a;
				});
