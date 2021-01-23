    public static XDocument MergeXml(this XDocument xd1, XDocument xd2)
    {
    	return new XDocument(
    		new XElement(xd2.Root.Name,
    			xd2.Root.Attributes()
    				.Concat(xd1.Root.Attributes())
    				.GroupBy (g => g.Name)
    				.Select (s => s.First()),
    			xd2.Root.Elements()
    				.Concat(xd1.Root.Elements())
    				.GroupBy (g => g.Name)
    				.Select (s => s.First())));
    }
