    foreach (var newElement in newXmlDoc.Element("blocker").Elements("lst"))
    {
    	newElement.Value.Trim().Dump();
    	if (!originalXmlDoc.Element("blocker").Elements("lst")
    	              .Any(oldElement => oldElement.Value.Trim().Equals(
    				      newElement.Value.Trim(), 
    					  StringComparison.InvariantCultureIgnoreCase)))
    	{
    		originalXmlDoc.Element("blocker").Add(new XElement("lst", newElement.Value));
    	}
    }
    originalXmlDoc.Save(originalFilename, SaveOptions.None);
