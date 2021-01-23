	Version newVersion = null;
	string xmlUrl = "http://www.yourXmlLocation.com/test123.xml";
	XmlTextReader reader = null;
	try
	{ 
		reader = new XmlTextReader(xmlUrl);
		reader.MoveToContent();
		string elementName = "";
		if((reader.NodeType == XmlNodeType.Element ) && (reader.Name == "test1"))
		{
			while (reader.Read())
			{
				if(reader.NodeType == XmlNodeType.Element)
				{
					elementName = reader.Name;
				}
				else
				{
					if((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
					{
						switch(elementName)
						{
							case "version":                                        
								versionString = reader.Value;
								break;
							case "url":
								downloadUrl = reader.Value;
								break;
						}
					}
				}
			}
		}
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex);
	}
	if (reader != null)
		reader.Close();
