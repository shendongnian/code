	var results = xs.Aggregate<int, List<List<int>>>(
		new List<List<int>> { new List<int>() },
		(a, n) =>
		{
			if (a.Last().Sum() + n > 5)
			{
				a.Add(new List<int> { n });
			}
			else
			{
				a.Last().Add(n);
			}
			return a;
		});
