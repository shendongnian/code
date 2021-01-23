	protected string OnTransformXml(string xml)
	{
		var doc = XDocument.Parse(xml);
		var root = doc.Descendants("root").FirstOrDefault();
		var allResults = doc.Descendants("Result").ToList();
		foreach (var node in allResults)
		{
			// remove all Result elements from their current location
			node.Remove();
			// rename the Result element to RawResult
			node.Name = "RawResult";
			// create a container for the Result elements to live in
			var rawMembersElement = new XElement("Result");
			// add each Result element to the new container
			rawMembersElement.Add(node);
			// add the new container
			root.Add(rawMembersElement);
		}
		return doc.ToString();
	}
