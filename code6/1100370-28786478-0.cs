    public static IEnumerable<string> ReadLinesFromStream(Stream stream)
    {
        using ( BinaryReader binaryReader = new BinaryReader(stream) )
        {
            var bytes = new List<byte>();
            while ( binaryReader.PeekChar() != -1 )
            {
                bytes.Add(binaryReader.ReadByte());
                bool newLine = bytes.Count > 2
                    && bytes[bytes.Count - 3] == 0x0d
                    && bytes[bytes.Count - 2] == 0x0d
                    && bytes[bytes.Count - 1] == 0x0a;
                if ( newLine )
                {
                    yield return Encoding.UTF8.GetString(bytes.Take(bytes.Count - 3).ToArray());
                    bytes.Clear();
                }
            }
            if ( bytes.Count > 0 )
                yield return Encoding.UTF8.GetString(bytes.ToArray());
        }
    }
