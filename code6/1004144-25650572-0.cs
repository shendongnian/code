    XmlReader reader = XmlReader.Create(stream, new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Fragment });
    
    while (reader.Read())
    {
      using (XmlReader subTreeReader = reader.ReadSubtree())
      {
        XElement xmlData = XElement.Load(subTreeReader);
        Process(xmlData);
      }
    }
