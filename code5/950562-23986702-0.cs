    int k = 0;
    using (var stream = new FileStream(path, FileMode.Truncate))
    {
        using (var writer = new StreamWriter(stream))
        {
            writer.Write(k);
        }
    }
