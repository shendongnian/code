    XmlRootAttribute xRoot = new XmlRootAttribute();
    xRoot.ElementName = "GetRegistrationStatusRequest";
    Root.IsNullable = true;
    XmlSerializer serializer = new XmlSerializer(typeof(GetRegistrationStatusRequest), xRoot);
    request = (GetRegistrationStatusRequest)serializer.Deserialize(new StringReader(RequestXml.OuterXml));
