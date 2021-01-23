	try
	{	        
		var xsd = XDocument.Load("d:\\temp\\input.xsd");
		var ns = xsd.Root.GetDefaultNamespace();
		var prefix = xsd.Root.GetNamespaceOfPrefix("xs");
		// get Vehicle
		var vehicle = xsd.Root.Elements(prefix + "element").FirstOrDefault();
		// get sequence for Ford
		var sections = vehicle.Elements(prefix + "complexType").FirstOrDefault()
							.Elements(prefix + "sequence").FirstOrDefault()
							// the Ford element
							.Elements(prefix + "element").FirstOrDefault()
							.Elements(prefix + "complexType").FirstOrDefault()
							.Elements(prefix + "sequence").FirstOrDefault()
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
