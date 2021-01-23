	var entries = new List<string[]>(); // List of entries
	foreach (var e in str.Split('\n')) // Splits by new line .. Can be modified to whatever ...
	{
		if (string.IsNullOrWhiteSpace(e) || !e.Contains(" ")) // If the string is empty, whitespace or doesn't contain a space
			continue; // Skip to next line
		var entry = e.Split(' '); // Splits the entry by space
		if (entry.Length < 2) // If there is less than two entries
			continue; // Skip to next line
		if (entry.Length > 2) // Checks if there are more than two entries Ex. "Grand Rapids New Mexico"
		{
			var statePart1 = entry[entry.Length - 2]; // Gets the first part of the state
			var statePart2 = entry[entry.Length - 1]; // Gets the second part of the state
			// Note: statePart1 is invalid if the state only has one "word", statePart2 is valid in this case
			if (statePart1 == "North" || statePart1 == "South" || statePart1 == "New") // Checks if statePart1 is valid
			{
				int stateSize = statePart1.Length + statePart2.Length + 2; // Gets the state string size
				var state = string.Format("{0} {1}", statePart1, statePart2); // Creates the state string
				var city = e.Substring(0, e.Length - stateSize); // Gets the city string
				entries.Add(new string[] { state, city }); // Adds the entry to the entries
			}
			else
			{
				// If statePart1 is not valid then the state is a single "word"
				int cityLength = e.LastIndexOf(' '); // Gets the length of the city
				entries.Add(new string[] { statePart2, e.Substring(0, cityLength) }); // Adds the entry to the entries
			}
		}
		else
		{
			// If there is only two entries then both the city and state has only one "word"
			entries.Add(new string[] { entry[1], entry[0] }); // Adds the entry to the entries
		}
	}
