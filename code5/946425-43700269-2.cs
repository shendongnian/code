    public static UInt32 GetIntFromByteArray(Byte[] data, Int32 startIndex, Int32 bytes, Boolean littleEndian)
    {
        UInt32 value = 0;
        Int32 lastByte = bytes - 1;
        if (data.Length < startIndex + bytes)
            throw new ArgumentOutOfRangeException("startIndex", "Data array is too small to read a " + bytes + "-byte value from offset" + startIndex + ".");
        for (Int32 index = 0; index < bytes; index++)
        {
            Int32 offs = startIndex + (littleEndian ? lastByte - index : index);
            value |= (UInt32)(data[offs] << (index * 8));
        }
        return value;
    }
    public static void WriteIntToByteArray(Byte[] data, Int32 startIndex, Int32 bytes, Boolean littleEndian, UInt32 value)
    {
        Int32 lastByte = bytes - 1;
        if (data.Length < startIndex + bytes)
            throw new ArgumentOutOfRangeException("startIndex", "Data array is too small to read a " + bytes + "-byte value from offset" + startIndex + ".");
        for (Int32 index = 0; index < bytes; index++)
        {
            Int32 offs = startIndex + (littleEndian ? lastByte - index : index);
            data[offs] = (Byte)(value >> (8 * index) & 0xFF);
        }
    }
