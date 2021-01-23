    public static String ReadLastLine(string path)
    {
        return ReadLastLine(path, Encoding.ASCII, "\n");
    }
    public static String ReadLastLine(string path, Encoding encoding, string newline)
    {
        int charsize = encoding.GetByteCount("\n");
        byte[] buffer = encoding.GetBytes(newline);
        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            long endpos = stream.Length / charsize;
            for (long pos = charsize; pos < endpos; pos += charsize)
            {
                stream.Seek(-pos, SeekOrigin.End);
                stream.Read(buffer, 0, buffer.Length);
                if (encoding.GetString(buffer) == newline)
                {
                    buffer = new byte[stream.Length - stream.Position];
                    stream.Read(buffer, 0, buffer.Length);
                    return encoding.GetString(buffer);
                }
            }
        }
        return null;
    }
