    Top topOut;
    using (var stream = new MemoryStream())
    {
        var writer = new StreamWriter(stream);
        writer.Write(serialized);
        writer.Flush();
        stream.Position = 0;
        topOut = (Top) _model.Deserialize(stream, null, typeof (Top));
    }
