	// XMLs
	string oldXML = @"<Books>
	<book id='1' image='C01' name='C# in Depth'/>
	<book id='2' image='C02' name='ASP.NET'/>
	<book id='3' image='C03' name='LINQ in Action '/>
	<book id='4' image='C04' name='Architecting Applications'/>
	</Books>";
	string newXML = @"<Books>
	<book id='1' image='C011' name='C# in Depth'/>
	<book id='2' image='C02' name='ASP.NET 2.0'/>
	<book id='3' image='XXXC03' name='XXXLINQ in Action '/>
	<book id='4' image='C04' name='Architecting Applications'/>
	<book id='5' image='C05' name='PowerShell in Action'/>
	</Books>";
	// xml documents
	var xmlOld = XDocument.Parse(oldXML);
	var xmlNew = XDocument.Parse(newXML);
	// helper function to get the attribute value of the given element by attribute name
	Func<XElement, string, string> getAttributeValue = (xElement, name) => xElement.Attribute(name).Value;
	// nodes for which we are looking for
	var nodeName = "book";
	// iterate over all old nodes (this will replace all existing but changed nodes)
	xmlOld.Descendants(nodeName).ToList().ForEach(item =>
	{
		var currentElementId = getAttributeValue(item, "id");
		// find node with the same id in the new nodes collection
		var toReplace = xmlNew.Descendants(nodeName).ToList().FirstOrDefault(n => getAttributeValue(n, "id") == currentElementId);
		if (toReplace != null)
		{
			// replace attribute values
			item.Attribute("image").Value = getAttributeValue(toReplace, "image");
			item.Attribute("name").Value = getAttributeValue(toReplace, "name");
		}
	});
	// add new nodes
	// id's of all old nodes
	var oldNodes = xmlOld.Descendants(nodeName).Select (node => getAttributeValue(node, "id")).ToList();
	// id's of all new nodes
	var newNodes = xmlNew.Descendants(nodeName).Select (node => getAttributeValue(node, "id")).ToList();
	// find new nodes that are not present in the old collection
	var nodeIdsToAdd = newNodes.Except(oldNodes);
	// add all new nodes to the already modified xml document
	foreach (var newNodeId in nodeIdsToAdd)
	{
		var newNode = xmlNew.Descendants(nodeName).FirstOrDefault(node => getAttributeValue(node, "id") == newNodeId);
		if (newNode != null)
		{
			xmlOld.Root.Add(n);
		}
	}
	xmlOld.Save(@"d:\temp\merged.xml");
