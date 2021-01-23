	Func<IEnumerable<int>, IEnumerable<int>> getAllSelectionSums = null;
	getAllSelectionSums = xs =>
	{
		if (!xs.Any())
		{
			return new [] { 0 };
		}
		else
		{
			return
				from h in xs.Take(1).Concat(new [] { 0 })
				from t in getAllSelectionSums(xs.Skip(1))
				select h + t;
		}
	};
