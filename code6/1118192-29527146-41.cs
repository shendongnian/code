    Top topIn = new TopTestBuilder().BuildDefaultTestTop();
    string serialized;
    using (var stream = new MemoryStream())
    {
        model.Serialize(stream, top);
        stream.Position = 0;
        var reader = new StreamReader(stream);
        serialized = reader.ReadToEnd();
    }
