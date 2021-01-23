    using (XmlWriter writer = XmlWriter.Create("GiveNameToYourFile.xml"))
	{
	    writer.WriteStartDocument();
	    writer.WriteStartElement("GiveTagNameToYourDocument");
	    foreach (proxy.ProjectData som in nc)
	    {
		writer.WriteStartElement("GiveNameToYourElement");
		writer.WriteElementString("ProjectTitle", som.ProjectTitle);
		writer.WriteElementString("ProjectID", som.ProjectID);
		writer.WriteElementString("PublishStatus", som.PublishStatus);
		writer.WriteEndElement();
	    }
	    writer.WriteEndElement();
	    writer.WriteEndDocument();
	}
