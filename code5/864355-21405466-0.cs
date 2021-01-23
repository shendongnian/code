    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Indent = true;
    settings.OmitXmlDeclaration = true;
    StringBuilder sb = new StringBuilder();
    XmlWriter writer = XmlWriter.Create(sb, settings);
    
    writer.WriteStartDocument();
    
    writer.WriteStartElement("Tests");
    writer.WriteStartElement("Test");
    writer.WriteAttributeString("Test", message);
    writer.WriteElementString("DateAndTime", time);
    writer.WriteElementString("Result", test);
    writer.WriteEndElement();
    writer.WriteEndElement();
    writer.WriteEndDocument();
    writer.Flush();
    writer.Close();
    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\\log.xml", true))
    {
        file.Write(sb.ToString());
    }
