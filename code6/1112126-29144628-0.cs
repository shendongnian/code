    List<string> lines = new List<string>();
    using(var ms = new MemoryStream(x23.FileData))
    using(var reader = new StreamReader(ms, Encoding.UTF8))
    {
        string line;
        while((line = reader.ReadLine()) != null)
            lines.Add(line);
    }
