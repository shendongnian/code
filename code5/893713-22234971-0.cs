	// get lines
	var lines = File.ReadLines("someFile");
	// what I am looking for
	var clues = new List<string> { "Cat", "Dog" };
	// filter 1. Are there clues? This is if you only want to know
	var haveCluesInLines = lines.Any(l => clues.Any(c => l.Contains(c)));
	// filter 2. Get lines with clues
	var linesWithClues = lines.Where(l => clues.Any(c => l.Contains(c)));
