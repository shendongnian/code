    byte[] bytes = { 0x03, 0x04, 0x05, 0x06 };
    
    // If the system architecture is little-endian (that is, little end first), reverse the byte array.
    if (BitConverter.IsLittleEndian)
    {
        Array.Reverse(bytes);
    }
    
    int i = BitConverter.ToInt32(bytes, 0);
    Console.WriteLine("int: {0}", i);
