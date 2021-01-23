    // Reading it
    string foo;
    byte[] itemData = Convert.FromBase64String(bar);
    using (MemoryStream src = new MemoryStream(itemData))
    using (GZipStream gzs = new GZipStream(src, CompressionMode.Decompress))
    using (StreamReader reader = new StreamReader(gzs, Encoding.UTF8))
    {
        foo = reader.ReadLine();
    }
