    static IEnumerable<sbyte> ReadSBytes(string path)
    {
        using (var stream = File.OpenRead(path))
        using (var reader = new BinaryReader(stream))
        {
            while (true)
            {
                sbyte sb;
                try
                {
                    sb = reader.ReadSByte();
                }
                catch(EndOfStreamException)
                {
                    break;
                }
                return sb;
            }
        }
    }
    sbyte[] sbytes = ReadSBytes("fileName").ToArray();
