	var outOfStockRanges =
		outOfStock
			.Skip(1)
			.Aggregate(
				outOfStock
					.Take(1)
					.Select(x => new { From = x.Date, To = x.Date })
					.ToList(),
				(a, x) =>
				{
					if (a.Last().To.AddDays(1.0) == x.Date)
						a[a.Count - 1] = new { From = a.Last().From, To = x.Date };
					else
						a.Add(new { From = x.Date, To = x.Date });
					return a;
				});
