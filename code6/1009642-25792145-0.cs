    using (var writer = new XmlTextWriter("ResultFile.xml")
    {
    	writer.WriteStartDocument();
    	writer.WriteStartElement("Data");
    	using (var reader = new XmlTextReader("XmlFile1.xml")
    	{
    		reader.Read();
    		while (reader.Read())
    		{
    			writer.WriteNode(reader, true);
    		}
    	}
    	using (var reader = new XmlTextReader("XmlFile2.xml")
    	{
    		reader.Read();
    		while (reader.Read())
    		{
    			writer.WriteNode(reader, true);
    		}
    	}
    	writer.WriteEndElement("Data");
    }
