    using (var fileStream = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    using (XmlReader reader = new XmlTextReader(fileStream, XmlNodeType.Element, null))
    {
    	while (reader.Read())
    	{
    		if (reader.Name == "E2ETraceEvent" && reader.NodeType == XmlNodeType.Element)
    		{
    			using (XmlReader subReader = reader.ReadSubtree())
    			{
    				while (subReader.Read())
    				{
    					var elementString = subReader.ReadOuterXml();
    					if (!string.IsNullOrWhiteSpace(elementString))
    					{
    						using (var xStream = this.GenerateStreamFromString(elementString))
    						{
    							XElement traceElement = XElement.Load(xStream);
    							var serializer = new XmlSerializer(typeof(E2ETraceEvent));
    							var traceObject = (E2ETraceEvent)serializer.Deserialize(traceElement.CreateReader());
    							
    							var formattedXml = this.SerializeToXmlString<E2ETraceEvent>(traceObject); 
    						}
    					}
    				}
    			}
    		}
    	}
    }
    ====================================
    
    private Stream GenerateStreamFromString(string s)
    {
    	var stream = new MemoryStream();
    	var writer = new StreamWriter(stream);
    	writer.Write(s);
    	writer.Flush();
    	stream.Position = 0;
    	return stream;
    }
    =====================================
    
    private string SerializeToXmlString<T>(T objectToSerialize)
    {
    	XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
    	var settings = new XmlWriterSettings
    	{
    		Indent = true,
    		OmitXmlDeclaration = true
    	};
    	var xml = string.Empty;
    
    	using (var sw = new StringWriter())
    	{
    		using (XmlWriter writer = XmlWriter.Create(sw, settings))
    		{
    			xmlSerializer.Serialize(writer, objectToSerialize);
    			xml = sw.ToString();
    		}
    	}
    
    	return xml;
    }
    ======================================
