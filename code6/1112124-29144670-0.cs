	configData.AsEnumerable()
		.GroupBy(r => r["myColumn"])
		.Select(g => new
		{
			myColumnValue = g.Key, 
			myColumnItems = g.Select(r => r["OtherColumn"]).ToList()
		});
