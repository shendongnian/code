    XDocument doc = new XDocument();
    using (XmlWriter writer = doc.CreateWriter())
    {
        // Do this directly 
        writer.WriteStartDocument();
        writer.WriteStartElement("root");
        writer.WriteElementString("foo", "bar");
        writer.WriteEndElement();
        writer.WriteEndDocument();
        // or anything else you want to with writer, like calling functions etc.
    }
