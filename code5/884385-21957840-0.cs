    XmlReader rdr = XmlReader.Create(new System.IO.StringReader(xml));
    while (rdr.Read())
    {
        if (rdr.NodeType == XmlNodeType.Element)
        {
           if (rdr.LocalName.Equals("name"))
           {
               Console.WriteLine(rdr.Value);
           }
        }
     }
