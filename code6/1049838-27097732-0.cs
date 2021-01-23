	using System;
	using System.Linq;
	using System.Collections.Generic;
	
	string[] records = new string[] { //File.ReadAllLines to get from the file
		"emily",
		"adrian",
		"camille",
		"lim",
		"ong",
		"ang"
	};
	
	bool sortByFirstName = true; // Set to false if by last name
	int range = records.Length / 2;
	
	var items = new List<string>();
	for (int i = 0; i < range; i++)
	{
		if (sortByFirstName == true)
			items.Add(string.Format("{0} {1}", records[i], records[i+range]));
		else
			items.Add(string.Format("{1} {0}", records[i], records[i+range]));
	}
	var sortedItems = items.OrderBy(s => s);
	foreach (var s in sortedItems)
		Console.WriteLine(s);
