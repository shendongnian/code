	var xmlEntry = importList.SelectMany(y => y.Entries)
                             .FirstOrDefault(entry => entry.Name.Equals("file.xml",
                                                      StringComparison.OrdinalIgnoreCase));
	if (xmlEntry == null)
	{
		return;
	}
	
    // Open a stream to the underlying ZipArchiveEntry
	using (XDocument xml = XDocument.Load(xmlEntry.Open()))
	{
		// Do stuff with XML
	}
