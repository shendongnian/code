    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(MyInfo[]));
    using (var writer = new StreamWriter("SerializedValues.xml"))
    {
        serializer.Serialize(writer, dic.Values.ToArray());
    }
