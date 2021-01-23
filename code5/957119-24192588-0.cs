		var xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
	<root>
		<element>YUP</element>
		<element>YUP</element>
		<element>YUP</element>
	</root>";
	try
	{
		var document = XDocument.Parse(xml);
		var root = document.Root;
		// get all "element" elements
		var yups = root.Descendants("element");
		// get a copy of the nodes that are to be moved inside new node
		var copy = yups.ToList();
		// remove the nodes from the root
		yups.Remove();
		// put them in the new sub node
		root.Add(new XElement("newSubRoot", copy));
		// output or save
		Console.WriteLine(document.ToString()); // document.Save("c:\\xml.xml");
	}
	catch (Exception exception)
	{
		Console.WriteLine(exception.Message);
	}
