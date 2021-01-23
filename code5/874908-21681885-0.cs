    var stream = webRequest.GetResponse().GetResponseStream();
    MemoryStream m = new MemoryStream();
    new System.IO.Compression.GZipStream(stream, System.IO.Compression.CompressionMode.Decompress).CopyTo(m);
    try
    {
        string str = Encoding.UTF8.GetString(m.ToArray()); 
        Console.Write(str);
        Console.Read();
    }
    finally
    {
     ........
    }
