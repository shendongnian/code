    public static void CopyFileChunked(int chunkSize, string filepath, string output)
    {
        byte[] chunk = new byte[chunkSize];
        using (FileStream reader = new FileStream(filepath, FileMode.Open))
        using (FileStream writer = new FileStream(output, FileMode.Create))
        {
            int bytes;
            while ((bytes = reader.Read(chunk , 0, chunkSize)) > 0)
            {
                writer.Write(chunk, 0, bytes);
            }
        }
    }
