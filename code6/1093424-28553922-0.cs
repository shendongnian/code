    // Encapsulate the behavior in an extension method we can run
    // directly on a StringBuilder object
	public static StringBuilder DeduplicateColumns(this StringBuilder input) {
        // Assume that we can split into large "chunks" on spaces
		var sections = input.ToString().Split(' ');
		var resultSections = new List<string>();
		
		foreach (var section in sections) {
			var items = section.Split(',');
            // If there aren't any commas, spit this chunk back out
            // Otherwise, split on the commas and get distinct items
			if (items.Count() == 1)
				resultSections.Add(section);
			else
				resultSections.Add(string.Join(",", items.Distinct()));
		}
		
		return new StringBuilder(string.Join(" ", resultSections));
	}
