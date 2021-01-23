    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Address));
    byte[] data;
    using (var ms = new MemoryStream())
    {
        serializer.Serialize(ms, address);
        raw = ms.ToArray();
    }
    DoSomethingWith(data);
