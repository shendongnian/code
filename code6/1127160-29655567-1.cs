    public ushort GetUInt16(byte[] bytes)
    {
        ReverseIfLittleEndian(bytes);
        return BitConverter.ToUInt16(bytes, 0);
    }
    public uint GetUInt32(byte[] bytes)
    {
        ReverseIfLittleEndian(bytes);
        return BitConverter.ToUInt32(bytes, 0);
    }
    public ulong GetUInt64(byte[] bytes)
    {
        ReverseIfLittleEndian(bytes);
        return BitConverter.ToUInt64(bytes, 0);
    }
    private static void ReverseIfLittleEndian()
    {
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }
    }
