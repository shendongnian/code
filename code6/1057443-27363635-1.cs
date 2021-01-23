    // Assuming the following class as a destination type
    class Foo
	{
		public Foo(string[] values)
		{
			Code = values[0];
			Name = values[1];
			Desc = values[2];
		}
		
		public string Code;
		public string Name;
		public string Desc;
	}
    // This would be the code required to parse the data
    var destination = dataSource["Code"].Aggregate(new List<Foo>(), (entries, _) => 
	{
		var curentRow = entries.Count();
		
		var entryData = dataSource.Select(property => property.Value[curentRow]).ToArray();
		
		entries.Add(new Foo(entryData));
		
		return entries;
	});
