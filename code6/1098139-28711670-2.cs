    var query = queryResultFilter.OrderBy(t => t.Day)
								 .ToLookup(t => t.Day);
	foreach (var group in query) {
		Console.WriteLine(group.Key);
		foreach (var item in group) {
			Console.WriteLine("CustomerNumber: {0}", item.CustomerNumber);
			Console.WriteLine("Product: {0}", item.Product);
		}
		Console.WriteLine();
	}
