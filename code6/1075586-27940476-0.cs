    public static byte[] ReadAllBytes(String path)
    {
        byte[] bytes;
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            int index = 0;
            long fileLength = fs.Length;
            if (fileLength > Int32.MaxValue)
                throw new IOException(“File too long”);
            int count = (int)fileLength;
            bytes = new byte[count];
            while (count > 0)
            {
                int n = fs.Read(bytes, index, count);
                if (n == 0)
                    throw new InvalidOperationException(“End of file reached before expected”);
                index += n;
                count -= n;
            }
        }
    return bytes;
    }
