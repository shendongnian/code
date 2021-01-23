	List<int?> nullableInts = new List<int?>();
	// Lets generate some data to play with...
	for (int i = 0; i < 100; i++)
	{
		int? digit = i % 2 == 0 ? (int?)null : i;
		nullableInts.Add(digit);
	}
	// Below we use the GetValueOrDefault method to convert all null integers to -1
	List<int> ints = nullableInts.Select(x => x.GetValueOrDefault(-1)).ToList();
	
	// Below we simply cast the nullable integer to an integer
	List<int> filteredInts = nullableInts.Where(x => x.HasValue)
										 .Select(x => (int)x).ToList();
