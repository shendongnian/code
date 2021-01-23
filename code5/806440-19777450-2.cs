    uint data_in = 0xdeadbeef;
    ushort data_out;
    byte next_data_out;
    // pay attention to BitConverter.IsLittleEndian here!
    // you might need to write your own conversion methods,
    // or do a Reverse() or find a better library
    var bits = new BitArray(BitConverter.GetBytes(data_in));
    if (bits.TryConvertToUInt16(out data_out, 10))
    {
        Console.WriteLine(data_out.ToString("X")); // 2EF
        if (bits.TryConvertToByte(out next_data_out, 6, 10))
        {
            Console.WriteLine(next_data_out.ToString("X")); // 2F
        }
    }
    private static bool Validate(BitArray bits, int len, int start, int size)
    {
        return len < size * 8 && bits.Count > start + len;
    }
    public static bool TryConvertToUInt16(this BitArray bits, out ushort output, int len, int start = 0)
    {
        output = 0;
        if (!Validate(bits, len, start, sizeof(ushort)))
            return false;
        for (int i = start; i < len + start; i++)
        {
            output |= (ushort)(bits[i] ? 1 << (i - start) : 0);
        }
        return true;
    }
    public static bool TryConvertToByte(this BitArray bits, out byte output, int len, int start = 0)
    {
        output = 0;
        if (!Validate(bits, len, start, sizeof(byte)))
            return false;
        for (int i = start; i < len + start; i++)
        {
            output |= (byte)(bits[i] ? 1 << (i - start) : 0);
        }
        return true;
    }
