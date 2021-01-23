	Func<
		Dictionary<string, string>,
		Dictionary<string, string>,
		Dictionary<string, string>> merge = (d1, d2) =>
	{
		var d = new Dictionary<string, string>(d1);
		foreach (var kv in d2)
		{
			d.Add(kv.Key, kv.Value);
		}
		return d;
	};
	
	var combinations =
		myDictionary
			.Select(x =>
				x.Value.Select(v =>
					new Dictionary<string, string>()
					{
						{ x.Key, v }
					}))
			.Aggregate((xs, vs) =>
				from x in xs
				from v in vs
				select merge(x, v));
