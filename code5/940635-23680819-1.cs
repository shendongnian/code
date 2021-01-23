        XmlDocument doc = new XmlDocument();
        doc.Load("xml.txt");
        XmlReader rdr = XmlReader.Create(new StringReader(doc.InnerXml));
        while (rdr.Read())
        {
            if (rdr.NodeType == XmlNodeType.Element)
            {
                Console.WriteLine(rdr.LocalName);
            }
        }
