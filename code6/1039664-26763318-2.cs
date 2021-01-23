    var duplicates = xml.Descendants("content")
            .GroupBy(g => (string)g.Value)
            .Where(g => g.Count() > 1)
			.SelectMany(g => g.Take(1));
			
	duplicates.Remove();
