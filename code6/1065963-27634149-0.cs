        MemoryStream ms = new MemoryStream();
        using (var writer = new StreamWriter(ms))
        {
            writer.WriteLine("testing a string");
        }
        byte[] contentBytes = ms.ToArray();
        string content = System.Text.Encoding.UTF8.GetString(contentBytes);
