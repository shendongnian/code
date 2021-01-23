    XmlSerializerNamespaces namespace = new     XmlSerializerNamespaces();
    //empty namespace and empty value
    namespace.Add("", "");
    XmlSerializer serializer = new XmlSerializer(someType);
    //Serialize the object with custom namespace
    serializer.Serialize(xmlTextWriter, myObj, namespace);
