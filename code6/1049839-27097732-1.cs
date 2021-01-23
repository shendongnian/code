	using System;
	using System.Linq; // Utilizing linq to perform sorting
	using System.Collections.Generic; // Utilizing generic List to accumulate objects
	
    // Statically provide sample data, but should use File.ReadAllLines when loading from file
	string[] records = new string[] { //File.ReadAllLines to get from the file
		"emily",
		"adrian",
		"camille",
		"lim",
		"ong",
		"ang"
	};
	
	bool sortByFirstName = true; // Set to false if by last name
	int range = records.Length / 2; // Since source data splits first and last names into same list, use value to define split between where first name stops and last name starts
	var items = new List<string>(); // Define list to contain the sortable items 
    // Iterate through the first and last names to gather the sortable names
	for (int i = 0; i < range; i++)
	{
		if (sortByFirstName == true) // If sorting by first name, format entry as "first last"
			items.Add(string.Format("{0} {1}", records[i], records[i+range]));
		else // Otherwise, sort by last name, format entry as "last first"
			items.Add(string.Format("{1} {0}", records[i], records[i+range]));
	}
	var sortedItems = items.OrderBy(s => s); // Use Linq to perform sorting
	foreach (var s in sortedItems)
		Console.WriteLine(s); // Output the results
