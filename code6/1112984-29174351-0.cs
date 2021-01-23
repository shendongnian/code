    reader.Read();
	while (!reader.EOF)
	{
		if (reader.NodeType == XmlNodeType.Element && reader.Name == elementName)
		{
			item = XElement.ReadFrom(reader) as XElement;
			if (item != null) 
			{
				yield return item;
			}
		}
		else
		{
		    reader.Read();
		}
	}
