    using (MemoryMemoryStream stream = new MemoryStream())
    {
        using (BZip2Stream zip = new BZip2Stream(stream, SharpCompress.Compressor.CompressionMode.Compress))
        {
            zip.Write(data, 0, data.Length);
            zip.Close();
        }
        var compressed = Encoding.UTF8.GetString(stream.ToArray());
        return compressed;
    }
