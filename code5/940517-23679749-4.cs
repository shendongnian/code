	try
	{	        
		var xsd = XDocument.Load("d:\\temp\\input.xsd");
		var ns = xsd.Root.GetDefaultNamespace();
		var prefix = xsd.Root.GetNamespaceOfPrefix("xs");
		// get Vehicle
		var vehicle = xsd.Root.Element(prefix + "element");
		// get sequence for Ford
		var sections = vehicle.Element(prefix + "complexType")
							.Element(prefix + "sequence")
							// the Ford element
							.Element(prefix + "element")
							.Element(prefix + "complexType")
							.Element(prefix + "sequence")
							// elements
							.Elements(prefix + "element").ToList();
		foreach (var section in sections)
		{
			Console.WriteLine(section.Attribute("name").Value);
			// for each section element
			var items = section.Element(prefix + "complexType")
								.Element(prefix + "sequence")
								// take the test elements
								.Elements(prefix + "element");
			foreach (var item in items)
			{
				Console.WriteLine(item.Attribute("name").Value);
				// access another attributes or values here
			}
		}
	}
	catch (Exception exception)
	{
		Console.WriteLine(exception.Message);
	}
