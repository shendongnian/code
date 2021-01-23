    XmlReaderSettings settings = new XmlReaderSettings();
    settings.ConformanceLevel = ConformanceLevel.Fragment;
    var reader = XmlReader.Create(@"c:\temp\test.xml", settings);
    while (reader.Read())
    {
        if (reader.NodeType == XmlNodeType.Element)
        {
            var nodeName = reader.Name;
            reader.Read();
            var value = reader.Value;
        }
    }
