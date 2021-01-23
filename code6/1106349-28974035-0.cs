	var usageData = new List<UsageData>()
	{
		new UsageData {UsageType = "FIND", DupTrans  = 190, UniqTrans = 55 },
		new UsageData {UsageType = "PARTS", DupTrans  = 107, UniqTrans = 51 }
	};
	
	var dup = usageData
			.GroupBy(p => "Duplicate Transactions", p => p.DupTrans)
			.Select(g => new {
				name = "Duplicate Transactions",
				data = g.ToList()
			}).First();
	
	Console.WriteLine(dup.name);
	Console.WriteLine(string.Join(",", dup.data));
	var uniq  = usageData
				.GroupBy(p => "Unique Transactions", p => p.UniqTrans)
				.Select(g => new {
					name = "Unique Transactions",
					data = g.ToList()
				}).First();
	
	Console.WriteLine(uniq.name);
	Console.WriteLine(string.Join(",", uniq.data));
