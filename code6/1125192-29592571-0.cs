    String keyStr = "foobar";
    byte[] keyBytes = new byte[16];
    Encoding.ASCII.GetBytes(keyStr).CopyTo(keyBytes, 0);
    UInt32[] keyArr = new UInt32[4];
    if (BitConverter.IsLittleEndian)
        Array.Reverse(keyBytes);
    for (int i = 0; i < 4; i++)
        keyArr[i] = BitConverter.ToUInt32(keyBytes, i * 4);
