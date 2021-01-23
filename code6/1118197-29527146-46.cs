    Top topOut;
    using (var stream = new MemoryStream())
    {
        var writer = new StreamWriter(stream);
        writer.Write(serialized);
        writer.Flush();
        stream.Position = 0;
        topOut = Protobuf.Serializer.Deserialize<Top>(stream);
    }
