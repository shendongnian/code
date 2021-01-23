 	public InMemoryContext
	{
		public Dictionary<string, object> allSets = new Dictionary<string, object>();
		public InMemoryContext()
		{
			allSets.Add("classA", new InMemoryDbSet<ClassA>());
			allSets.Add("classB", new InMemoryDbSet<ClassB>());
			[...]
		}
		public IDbSet<ClassA> ClassASet { get
		{
			return allSets["classA"];
		}
		set
		{
			allSets["classA"] = Value
		}
		}
		[...]
		public void SaveChanges()
		{
		//TODO: this is relevant part
		foreach(var kvp in allSets)
		{
			kvp.Value.SaveChanges();
		}
		}
	}
