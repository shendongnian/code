    int byteCount;
    byte[] buffer = new byte[4096]; 
    using (GZipStream zs = new GZipStream(e.Result, CompressionMode.Decompress))
    {
        while ((byteCount = zs.Read(buffer, 0, buffer.Length)) > 0)
        {
            stream.Write(buffer, 0, byteCount);
        }
    }
