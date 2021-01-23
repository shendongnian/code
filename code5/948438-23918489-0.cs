	void Main()
	{
		var setList = new List<int>() {1,1,2,3,3,3};
		var setSize = setList.Count();
		
		var basePowerSet = PowerSet.Generate(setList);
		var results = PowerSet.PS;
		
		
		// Results generated in 1 Minute 23 seconds with no errors.
		
		foreach( var item in results)
		{
			Console.WriteLine(item.ToString2());
		}
		
		
	}
