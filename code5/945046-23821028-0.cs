    using (XmlWriter writer = XmlWriter.Create(<FilePath>)) 	{
    	    writer.WriteStartDocument();
    	    writer.WriteStartElement("UserInfo");
            writer.WriteElementString("FirstName", "ABC");
            writer.WriteElementString("Email", "abc@dc.com");
            -----
            writer.WriteEndElement();
    	    writer.WriteEndDocument();
    
            }
