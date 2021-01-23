    using (var mem = new MemoryStream())
    {
        using(var str = new GZipStream(mem, CompressionMode.Compress))
        {
            WriteMyDataToStream(str);
            str.Flush(); // in case the buffer is not flushed
        }
        context.Response.AddHeader("Content-Type", "application/octet-stream");
        context.Response.AddHeader("Content-Disposition","attachment; filename=file.zip");
        mem.WriteTo(context.Response.OutputStream);
    }
