    IEnumerable<IGrouping<int,Package>> groups = packages.GroupBy(p => p.VersionControlGetStatus()).OrderBy(g => g.Key);
    foreach(IGrouping<int,Package> g in groups)
	{
		Console.WriteLine("Key: {0} | Count: {1}", g.Key, g.Count());
		
		Package first = g.First();
		
		Console.WriteLine("First package in group: " + first.ToString());
	}
