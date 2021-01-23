    public void Serialize(Stream outputStream, T3 content)
    {
        using (var stream = new MemoryStream())
        {
            Serializer.Serialize(stream, content);
        }
    }
