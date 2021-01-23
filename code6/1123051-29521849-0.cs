    XDocument doc = XDocument.Load(@filePath);
    for (int i = 0; i < items.Count; i++)
    {
    	var result = doc.Descendants("Item").Any(x => x.Element("Text").Value.Equals(items[i]));
    	
    	if (!result)
    	{
    	
    	}
    }
    
    doc.Save(@filePath);
