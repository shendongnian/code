	var list = Enumerable.Range(1,80)
		.Concat(Enumerable.Range(100,31))
		.Concat(Enumerable.Range(200,51))
		.ToList();
	var missing = Enumerable.Range(1,7000)
		.Except(list)
		.ToList();
