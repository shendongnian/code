	var rootObject = JsonConvert.DeserializeObject<RootObject>(json);
	
	foreach (var male in rootObject.Men)
	{
		male.Sex = Sex.Man;
	}
	
	foreach (var female in rootObject.Women)
	{
		female.Sex = Sex.Women;
	}
	
	var startsWithJ = rootObject.Men.Concat(rootObject.Women)
                                .Where(x => x.Name.StartsWith("J",
                                            StringComparison.OrdinalIgnoreCase))
                                .ToList();
	foreach (var personStartsWithJ in startsWithJ)
	{
		Console.WriteLine (personStartsWithJ.Name);
		Console.WriteLine (personStartsWithJ.Sex);
	}
