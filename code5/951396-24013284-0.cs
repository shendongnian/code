	Func<
		IEnumerable<IEnumerable<int>>,
		IEnumerable<IEnumerable<int>>> f0 = null;
	f0 = xss =>
	{
		if (!xss.Any())
		{
			return new [] { Enumerable.Empty<int>() };
		}
		else
		{
			var query =
				from x in xss.First()
				from y in f0(xss.Skip(1))
				select new [] { x }.Concat(y);
			return query;
		}
	};
	
	Func<IEnumerable<IEnumerable<int>>, IEnumerable<string>> f =
		xss => f0(xss).Select(xs => String.Join(",", xs));
