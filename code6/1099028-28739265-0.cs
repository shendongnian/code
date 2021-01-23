	var SourceList = new List<string>()
	{
		"Obj_A", "Obj_B", "Obj_C", "Obj_D", "Obj_E", "Obj_F", "Obj_G",
	}; 
	var rnd = new Random();
	
	var ResultList =
		Enumerable
			.Repeat(0, int.MaxValue)
			.Select(_ => Enumerable.Range(0, SourceList.Count)
				.OrderBy(x => rnd.Next())
				.ToArray())
			.Where(x => !x.Where((y, i) => y == i).Any())
			.Take(1)
			.SelectMany(x => x)
			.Select(x => SourceList[x])
			.ToList();
			
