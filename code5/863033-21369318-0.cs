	var input = new[]{
		new Pair(1, 1),
		new Pair(5, 2),
		new Pair(1, 2),
		new Pair(2, 1),
		new Pair(7, 4),
		new Pair(3, 1),
		new Pair(7, 2)
	};
	
	SortedDictionary<int, List<Pair>> pairs = 
		new SortedDictionary<int, List<Pair>>();
	
	foreach(var pair in input)
	{
		if (!pairs.ContainsKey(pair.First))
			pairs.Add(pair.First, new List<Pair>());
		
		pairs[pair.First].Add(pair);
	}
