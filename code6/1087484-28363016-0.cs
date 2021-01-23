	var ids = r.Select(x => x.Id).Distinct().OrderBy(x => x).ToArray();
	
	var query =
		from x in r
		group x by x.DateTime into gxs
		let lookup = gxs.ToLookup(x => x.Id, x => (int?)x.Value)
		select new
		{
			DateTime = gxs.Key,
			Values = ids.Select(i => new
			{
				Id = i,
				Value = lookup[i].FirstOrDefault(),
			}).ToArray(),
		};
