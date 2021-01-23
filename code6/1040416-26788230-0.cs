	public static IEnumerable<XElement> StreamItem(string uri)
	{
		using (var reader = XmlReader.Create(uri))
		{
			XElement campaign = null;
			reader.MoveToContent();
			// Loop through <Campaign /> elements
			reader.Read();
			while (!reader.EOF)
			{
				if (reader.NodeType == XmlNodeType.Element && reader.Name == "Campaign")
				{
					campaign = XNode.ReadFrom(reader) as XElement;
					yield return campaign;
				}
				else
				{
					reader.Read();
				}
			}
		}
	}
