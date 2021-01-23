    //Serialize value
    using (var memStream = new MemoryStream(buffer))
    using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(memStream))
    {
        serializer.WriteObject(writer, testValue);
        writer.WriteWhitespace(" ");
    }
    
    //Deserialize value
    using (var memStream = new MemoryStream(buffer))
    using (XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(memStream, XmlDictionaryReaderQuotas.Max))
    {
        object deserializedValue = serializer.ReadObject(reader); // \o/
        Console.WriteLine(deserializedValue);
    }
