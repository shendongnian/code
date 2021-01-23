    using (FileStream file = new FileStream("output.xml",FileMode.Create,FileAccess.Write,FileShare.None)) {
    
        XmlTextWriter xml = new XmlTextWriter(file);
    
        xml.WriteStartDocument();
        xml.WriteStartElement("Types");
    
        foreach(Match match in matches) {
            string type = match.Groups[1].Value;
            string param = match.Groups[2].Value;
    
            xml.WriteStartElement(type);
            xml.WriteAttributeString("name",param);
            xml.WriteEndElement();
        }
    
        xml.WriteEndElement();
        xml.WriteEndDocument();
        xml.Flush();
    
    }
