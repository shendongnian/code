	private String getValue(XDocument source, String name, String value)
	{
	//			return source
	//						.Root
	//						.Element(name)
	//						.Elements("item")
	//						.Where (f => f.Attribute("address").Value == value)
	//						.FirstOrDefault()
	//						.Value;
	// or alternative
		var result = (from e in source.Root.Element(name).Elements("item")
					where e.Attribute("address").Value == value
					select e.Value).FirstOrDefault();
		return result;
	}
