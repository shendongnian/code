    var XML =
        "<Doc><Description><![CDATA[<p><strong>Nokia</strong> connecting people</p>]]></Description></Doc>";
    XmlReader reader = XmlReader.Create(new StringReader(XML));
    string description ="";
    while (reader.Read())
    {
        if (reader.Name == "Description")
        {
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                reader.Read();
                if (reader.NodeType == XmlNodeType.CDATA)
                    description = reader.Value;
            }
        }
    }
    Console.Write(description);
