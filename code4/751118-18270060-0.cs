    static byte[] ReadAtLeast6()
    {
        return new byte[] { 0x0A, 0x0B, 0x68, 0x65, 0x6C, 0x6C, 0x6F };
    }
    static byte[] ReadMore(int bytes)
    {
        return new byte[] { 0x20, 0x77, 0x6F, 0x72, 0x6C, 0x64 };
    }
    static void Main()
    {
        // pretend we read 7 bytes async
        var data = ReadAtLeast6();
        using (var ms = new MemoryStream())
        {
            ms.Write(data, 0, data.Length);
            ms.Position = 0;
            int protoHeader = ProtoReader.DirectReadVarintInt32(ms); // 10
            int headerLength = ProtoReader.DirectReadVarintInt32(ms); // 11
            int needed = (headerLength + (int)ms.Position) - data.Length; // 6 more
            var pos = ms.Position;
            ms.Seek(0, SeekOrigin.End);
            data = ReadMore(needed);
            ms.Write(data, 0, needed);
            ms.Position = pos;
            string header = ProtoReader.DirectReadString(ms, headerLength);
        }
    }
