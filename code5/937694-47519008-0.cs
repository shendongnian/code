    using (var writer = new StringWriter())
    {
        writer.NewLine = "\r\n";
        var serializer = JsonSerializer.Create(
            new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            });
                    
        serializer.Serialize(writer, data);
        // do something with the written string
    }
