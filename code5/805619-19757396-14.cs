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
						Console.WriteLine(string.Format("Element - {0}", reader.Name));
						if (reader.HasAttributes)
						{
							for (var i = 0; i < reader.AttributeCount; i++)
							{
								Console.WriteLine(string.Format("Attribute - {0}", reader.GetAttribute(i)));
							}
							reader.MoveToElement();
						}
						break;
					case XmlNodeType.Text:
						Console.WriteLine(string.Format("Element value - {0}", reader.Value));
						break;
					//case XmlNodeType.XmlDeclaration:
					//case XmlNodeType.ProcessingInstruction:
					//	Console.WriteLine(reader.Name + " - " + reader.Value);
					//	break;
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
	// use the new function with the input from the first example
	parseUsingXmlReader(xml);
