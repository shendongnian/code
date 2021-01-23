	public void parseUsingXmlReader(string xmlString)
	{
		using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
		{
			XmlWriterSettings ws = new XmlWriterSettings();
			ws.Indent = true;
			while (reader.Read())
			{
				switch (reader.NodeType)
				{
					case XmlNodeType.Element:
						Console.WriteLine(reader.Name);
						break;
					case XmlNodeType.Text:
						Console.WriteLine(reader.Value);
						break;
					case XmlNodeType.XmlDeclaration:
					case XmlNodeType.ProcessingInstruction:
						Console.WriteLine(reader.Name + " - " + reader.Value);
						break;
					case XmlNodeType.Comment:
						Console.WriteLine(reader.Value);
						break;
					case XmlNodeType.EndElement:
						Console.WriteLine(reader.Value);
						break;
				}
			}
		}
	}
