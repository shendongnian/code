	var unsortedDictionary = input
		.GroupBy(p => p.Item1)
		.ToDictionary(g => g.Key, g => g.Select(i => i.Item2));
	
	var sortedDictionary = 
		new SortedDictionary<int, IEnumerable<int>>(unsortedDictionary);
