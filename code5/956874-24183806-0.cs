    var groups = packages.GroupBy(p => p.VersionControlGetStatus()).OrderBy(g => g.Key);
	
	foreach(var g in groups)
	{
		Console.WriteLine("Key: {0} | Count: {1}", g.Key, g.Count());
		
		Console.WriteLine("First package in group: " + g.First().ToString());
	}
