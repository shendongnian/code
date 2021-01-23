    using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
    {
        stream.Seek(-1, SeekOrigin.End);
        byte b = (byte)stream.ReadByte();
        char c = (char)b;
    }
