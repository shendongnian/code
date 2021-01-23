    private static bool IsAESNIPresent()
    {
        byte[] sn = new byte[16]; // !!! Here were 8 bytes
        if (!ExecuteCode(ref sn))
            return false;
        var ecx = BitConverter.ToUInt32(sn, 8);
        return (ecx & (1 << 25)) != 0;
    }
