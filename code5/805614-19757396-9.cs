	// sample class
	public class Entry
	{
		public string Name { get; set; }
		public int Count { get; set; }
	}
	// create and fill the object
	var entry = new Entry { Name = "test", Count = 10 };
	// create xml container
	var xmlToCreate = new XElement("entry", 
						new XAttribute("count", entry.Count),
						new XElement("name", entry.Name));
	// and save it
	xmlToCreate.Save(@"d:\temp\test.xml");
