	void Main()
	{
		var setList = new List<int>() {1,1,2,3,3,3};
		var setSize = setList.Count();
		
		var basePowerSet = PowerSet.Generate(setList);
		var results = PowerSet.PS;
		
		
		// Results generated in 1 Minute 23 seconds with no errors.
		
		var sortedSets = new SortedSet<string>();
		
		foreach( var item in results)
		{
			sortedSets.Add(item.ToString2());
		}
		
		foreach( var item in sortedSets)
		{
			Console.WriteLine(item);
		}	
		
		
	}
