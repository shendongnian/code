    private static async void EnGBNamesEtc()
    {
    		var listNames = new List<string>(){"some", "names");
    		var xdoc = XDocument.Load(@"C:\Users\ivandro\Source\subtitleedit\Dictionaries\en_GB_names_etc.xml");
    		var names = listNames.Except(xdoc.Root.Elements("name").Select(n => n.Value)).ToList();
    		foreach (var newName in names)
    		{
    			xdoc.Root.Add(new XElement("name", newName));
    		}
    		SaveToNewXml(xdoc, @"D:\Backup\en_GB_names_etc1.xml");
    }
    
    private static void SaveToNewXml(XDocument xdoc, string dest)
    {
    	XmlWriterSettings xws = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };
    	var ordered = xdoc.Root.Elements("name").OrderBy(element => element.Value).ToList();
    	using (XmlWriter xw = XmlWriter.Create(dest, xws))
    	{
    		xdoc.Root.ReplaceAll(ordered);
    		xdoc.Save(xw);
    	}
    }
