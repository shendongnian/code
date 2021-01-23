    var settings = new XmlWriterSettings();
    settings.Indent = true;
    using (XmlWriter writer = XmlWriter.Create("path_to_xml", settings))
    {
        writer.WriteStartElement("dlx");
        writer.WriteAttributeString("vars", "1.0");
        writer.WriteAttributeString("id", "133");
        writer.WriteAttributeString("type", "system_info");
        foreach (var d in devices)
        {
            writer.WriteStartElement("device");
            writer.WriteAttributeString("software", d.Software);
            foreach (var s in d.Sensors)
            {
                writer.WriteStartElement("sens");
                writer.WriteAttributeString("name", s.Name);
                foreach (var c in s.Channels)
                {
                    writer.WriteStartElement("chan");
                    writer.WriteAttributeString("id", c.Id.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        writer.WriteEndElement();
    }
