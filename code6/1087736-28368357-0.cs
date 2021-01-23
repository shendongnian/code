    IEnumerable<MyClass> results  = filteredObjectsByCodes.ToList();
	
	var missing = codesToFilter
		.Where(c => results.All(f => f.Property1 != c.Item1 && f.Property4 != c.Item2))
		.Select(c =>  new MyClass(tupleElement.Item1.. );
	
	results = results.Union(missing);
	
	var filteredObjectsResult = new HashSet<MyClass>(results);
	
	return filteredObjectsResult;
