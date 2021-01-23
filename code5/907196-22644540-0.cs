    using (XmlReader reader = XmlReader.Create(new StringReader("..."))
    {
       while (reader.Read())
       {
          if (reader.NodeType == XmlNodeType.Element)
          {
             ...
          }
       }
    }
