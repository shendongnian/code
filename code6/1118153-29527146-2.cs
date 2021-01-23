    Top topIn = new TopTestBuilder().BuildDefaultTestTop();
    string serialized;
    using (var stream = new MemoryStream())
    {
        Serializer.Serialize(stream, topIn);
        stream.Position = 0;
        var reader = new StreamReader(stream);
        serialized = reader.ReadToEnd();
    }
    // Output: "\nDC4\n\b\nACKFred20\n\b\nACKFred21DC2\b\nACKFred10DC2\b\nACKFred11"
