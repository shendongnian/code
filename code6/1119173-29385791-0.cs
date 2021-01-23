	private static void SortXml(XContainer parent)
	{
		var nodes = parent.Elements()
			.OrderByDescending(e => e.Name.LocalName)
			.ThenBy(e => (string)e.Attribute("name"))
			.ToArray();
		parent.RemoveNodes();
		foreach (var node in nodes) {
			parent.Add(node);
			SortXml(node);
		}
	}
