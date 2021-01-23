    static void ToBytes(ulong value, byte[] array, int offset)
    {
        for (int i = 0; i < 8; i++)
        {
            array[offset + i] = (byte)value;
            value >>= 8;
        }
    }
