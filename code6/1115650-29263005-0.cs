    public ulong Bit(ulong x, int n)
    {
        return (x & (1 << n)) >> n;
    }
    public ulong ReverseBits(ulong x)
    {
        ulong result = 0;
        for (int i = 0; i < 64; i++)
            result = result | (x.Bit(64 - i) << i);
        return result;
    }
