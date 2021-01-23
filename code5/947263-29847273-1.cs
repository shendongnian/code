    using (FileStream stream = File.Create(UploadPath + ImageName))
    {
        byte[] bytes = new byte[1024];
        long totalBytes = context.Request.InputStream.Length;
        long bytesRead = 0;
        int bytesToRead = bytes.Length;
        if (totalBytes - bytesRead < bytes.Length)
            bytesToRead = (int)(totalBytes - bytesRead);
        bytes = new byte[bytesToRead];
        while ((bytesToRead = context.Request.InputStream.Read(bytes, bytesRead, bytes.Length)) != 0)
        {
            stream.Write(bytes, bytesRead, bytes.Length);
            bytesRead += bytes.Length;
            if (totalBytes - bytesRead < bytes.Length)
                bytesToRead = (int)(totalBytes - bytesRead);
            bytes = new byte[bytesToRead];
        }
        stream.Close();
    }
