    async Task ConsumeStream(StreamReader reader, StringBuilder builder)
    {
        string line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            builder.AppendLine(line);
            Debug.WriteLine(line);
        }
    }
