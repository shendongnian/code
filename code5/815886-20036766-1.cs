    var map = new ModelMap();
    ...
    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ModelMap));
    using (var writer = new StreamWriter(@"e:\test.xml"))
    {
        serializer.Serialize(writer, map);
    }
