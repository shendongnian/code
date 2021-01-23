    int number = 0x1234;
    byte[] bytes = BitConverter.GetBytes(number);
    if (BitConverter.IsLittleEndian)
    {
        bytes = bytes.Reverse().ToArray();
    }
    BitArray ba = new BitArray(bytes);
