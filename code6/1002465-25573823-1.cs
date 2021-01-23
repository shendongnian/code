    byte[] buffer = BitConverter.GetBytes((ushort)0xfa2);
    if (BitConverter.IsLittleEndian) Array.Reverse(buffer);
    var b = new BitArray(new byte[]{1,3});
    for (int i = 0; i < b.Count; i+=8)
    {
		for (int j=i + 7; j >= i; j--)
		{
        	char c = b[j] ? '1' : '0';
        	Console.Write(c);
		}
    }
    Console.WriteLine();
