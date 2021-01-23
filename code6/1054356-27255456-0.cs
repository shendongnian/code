    // iterate over the list items
    foreach (var import in importList)
    {
        var fn = import.FileName;
    
        // iterate over the actual archives
        foreach (ZipArchiveEntry entry in import.ZipFile.Entries)
        {
            // only grab files that end in .xml
            if (entry.FullName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
            {
            	// this extracts the file
                entry.ExtractToFile(Path.Combine(@"C:\extract", entry.FullName));
    
                // this opens the file as a stream
                using(var stream = new StreamReader(entry.Open())){
                	// this opens file as xml stream
                	using(var xml = XmlReader.Create(stream){
                		// do some xml access on an arbitrary node
                		xml.MoveToContent();
                		xml.ReadToDescendant("my-node");
                		var item = xml.ReadElementContentAsString();
                	}
                }
            }
        }
    }
