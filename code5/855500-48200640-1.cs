    private UInt64 GetUInt64ForRowVersion(byte[] rowVersion)
    {
        byte[] rr = (byte[])rowVersion.Clone();
        if (BitConverter.IsLittleEndian) { Array.Reverse(rr); }
        return BitConverter.ToUInt64(rr, 0);
    }
