	var docNew = System.Xml.Linq.XDocument.Parse(doc);
	foreach (var element in docNew.Root.Descendants())
	{
		var textValue = string.Concat(element.Nodes().OfType<System.Xml.Linq.XText>().Select(tx => tx.Value));
		Console.WriteLine(string.Format("{0}: {1}", element.Name.ToString(), textValue));
	}
