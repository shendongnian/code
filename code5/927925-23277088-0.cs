	try
	{
		// add as many elements you want, they will appear only once!
		HashSet<String> uniqueTags = new HashSet<String>();
		// recursive helper delegate
		Action<XElement> addSubElements = null;
		addSubElements = (xmlElement) =>
		{
			// add the element name and 
			uniqueTags.Add(xmlElement.Name.ToString());
			// if the given element has some subelements
			foreach (var element in xmlElement.Elements())
			{
				// add them too
				addSubElements(element);
			}
		};
		
		// load all xml files
		var xmls = Directory.GetFiles("d:\\temp\\xml\\", "*.xml");
		foreach (var xml in xmls)
		{
			var xmlDocument = XDocument.Load(xml);
			// and take their tags
			addSubElements(xmlDocument.Root);
		}
		// list tags
		foreach (var tag in uniqueTags)
		{
			Console.WriteLine(tag);
		}
	}
	catch (Exception exception)
	{
		Console.WriteLine(exception.Message);
	}
