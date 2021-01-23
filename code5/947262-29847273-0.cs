    using (FileStream stream = File.Create(UploadPath + ImageName))
    {
        byte[] bytes = new byte[50000000]; // 
        int bytesToRead = 0;
        while ((bytesToRead = context.Request.InputStream.Read(bytes, 0, bytes.Length)) != 0)
        {
            stream.Write(bytes, 0, bytesToRead);
            stream.Close();
        }
    }
