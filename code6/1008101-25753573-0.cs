    public void ReadStream(HttpContext context, string filePath)
    {
        using (var reader = new StreamReader(context.Request.GetBufferlessInputStream(true)))
        using (var filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read, 4096, true))
        using (var writer = new StreamWriter(filestream))
        {
            var readBuffer = reader.ReadToEnd();
            writer.WriteAsync(readBuffer);
        }
    }
