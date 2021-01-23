	private static void SortXml(XContainer parent)
	{
		var elements = parent.Elements()
			.OrderByDescending(e => e.Name.LocalName)
			.ThenBy(e => (string)e.Attribute("name"))
			.ToArray();
		Array.ForEach(elements, e => e.Remove());
		foreach (var element in elements) {
			parent.Add(element);
			SortXml(element);
		}
	}
