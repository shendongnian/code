    rdr.MoveToContent();
    while (rdr.Read())
    {
        if (rdr.NodeType == XmlNodeType.Element)
        {                    
            string name = rdr.LocalName;
            string value = rdr.ReadInnerXml();
        }
    }
