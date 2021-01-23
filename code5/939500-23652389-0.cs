    public static string ReadLine(Stream stream)
    {
        return ReadLine(stream, Encoding.UTF8);
    }
    
    public static string ReadLine(Stream stream, Encoding encoding)
    {
        List<byte> lineBytes = new List<byte>();
        while (stream.Position < stream.Length)
        {
            byte b = (byte)stream.ReadByte();
            if (b == 0x0a)
                break;
            if (b == 0x0d)
                continue;
            lineBytes.Add(b);
        }
        return encoding.GetString(lineBytes.ToArray());
    }
