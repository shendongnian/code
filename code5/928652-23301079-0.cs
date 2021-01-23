	var xmlCode = @"<profile name=""FooBar""><btnA pressed=""actionA"" released=""actionB"" /><btnB pressed=""actionX"" released=""actionY"" /></profile>";
	try
	{
		// read existing XML structure
		var xml = XDocument.Parse(xmlCode); // XDocument.Load("c:\\path\\to\\file.xml");
		// find all button elements
		var buttons = xml.Root.Elements().Where (e => e.Name.ToString().StartsWith("btn"));
		foreach (var button in buttons)
		{
			// tag name
			var name = button.Name.ToString();
			// attributes
			var pressed = button.Attribute("pressed").Value;
			var released = button.Attribute("released").Value;
			Console.WriteLine(String.Format("{0} - P'{1}' - R'{2}'", name, pressed, released));
		}
		// create xml
		// root element
		var newXml = new XElement("profile", new XAttribute("name", "FooBaz"), 
						new XElement("btnA", 
							new XAttribute("pressed", "actionX"), 
							new XAttribute("released", "actionXR")),
						new XElement("btnB", 
							new XAttribute("pressed", "actionZ"), 
							new XAttribute("released", "actionZR")));
		Console.WriteLine(newXml.ToString());
	}
	catch (Exception exception)
	{
		Console.WriteLine(exception.Message);
	}
