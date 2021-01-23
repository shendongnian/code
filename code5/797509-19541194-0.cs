    using (MemoryStream buffer = new MemoryStream(response.ContentLength))
    {
        byte[] chunk = new byte[4096]; // <-- whatever chunk size
        int bytes;
        while ((bytes = stream.Read(chunk, 0, chunk.Length)) > 0)
        {
            buffer.Write(chunk, 0, bytes);
        }
    }
    byte[] bytes = buffer.ToArray();
