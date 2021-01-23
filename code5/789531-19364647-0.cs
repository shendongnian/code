    using (SftpClient client = new SftpClient(connectionInfo))
    {
        client.Connect();
        client.ChangeDirectory("/upload");
        using (MemoryStream outputStream = new MemoryStream())
        {
            using (var gzip = new GZipStream(outputStream, CompressionLevel.Fastest))
            {
                stream.CopyTo(gzip);                  
            }
            using (Stream stm = new MemoryStream(outputStream.ToArray()))
            {
                client.UploadFile(stm,"txt.gz");
            }
        }
    }
