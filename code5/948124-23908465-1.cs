    string s = "Biography:\u003clink type...";
    string bar;
    using (MemoryStream ms = new MemoryStream())
    {
        using (GZipStream gzip = new GZipStream(ms, CompressionMode.Compress))
        using (var writer = new BinaryWriter(gzip, Encoding.UTF8))
        {
            writer.Write(s);
        }
        ms.Flush();
        bar = Convert.ToBase64String(ms.ToArray());
    }
    // Reading it
    string foo;
    byte[] itemData = Convert.FromBase64String(bar);
    using (MemoryStream src = new MemoryStream(itemData))
    using (GZipStream gzs = new GZipStream(src, CompressionMode.Decompress))
    using (var reader = new BinaryReader(gzs, Encoding.UTF8))
    {
        foo = reader.ReadString();
    }
    Console.WriteLine(foo);
