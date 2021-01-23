    var obj = new MyElement() { Content = "testing" };
    var namespaces = new XmlSerializerNamespaces();
    namespaces.Add("xsi", MyElement.SchemaInstanceNamespace);
    namespaces.Add("myns", MyElement.ElementNamespace);
    var serializer = new XmlSerializer(typeof(MyElement));
    using (var writer = File.CreateText("serialized.xml"))
    {
        serializer.Serialize(writer, obj, namespaces);
    }
