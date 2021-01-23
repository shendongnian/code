	var SourceList = new List<string>()
	{
		"Obj_A", "Obj_B", "Obj_C", "Obj_D", "Obj_E", "Obj_F", "Obj_G",
	}; 
	var rnd = new Random();
	
	var ResultList =
		Enumerable
			// create an exceedingly long sequence for retries
			.Repeat(0, int.MaxValue)
			// select and randomly order all of the indices of `SourceList`
			.Select(_ => Enumerable.Range(0, SourceList.Count)
				.OrderBy(x => rnd.Next())
				.ToArray())
			// Discard the indices if they have any matching positions
			.Where(x => !x.Where((y, i) => y == i).Any())
			// only take one successful set of indices
			.Take(1)
			// flatten the list of lists to a list
			.SelectMany(x => x)
			// select the elements from `SourceList` from their index positions
			.Select(x => SourceList[x])
			// convert to list
			.ToList();
