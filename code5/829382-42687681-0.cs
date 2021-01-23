    //Serialize value
    using (var memStream = new MemoryStream(buffer))
    using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(memStream))
    {
        serializer.WriteObject(writer, testValue);
        writer.Flush();
    }
