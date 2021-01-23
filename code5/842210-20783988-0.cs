            XmlWriter writer = XmlWriter.Create("d:\\MyFirstXmlFile.xml", writerSettings);
    
            writer.WriteStartDocument();
            writer.WriteStartElement("People");
    
            writer.WriteStartElement("Person");
            writer.WriteElementString("Name", "Zain Shaikh");
            writer.WriteElementString("JobDescription", "Software Engineer");
            writer.WriteElementString("Facebook", "http://www.facebook.com/zainshaikh");
            writer.WriteEndElement();
    
            writer.WriteEndElement();
            writer.WriteEndDocument();
    
            writer.Flush();
