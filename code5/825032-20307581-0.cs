    public static uint getIndex(ushort value)
    {
        byte[] block = BitConverter.GetBytes(value);
        uint aVal = block[0];
        uint bVal = block[1];
        return  Convert.ToUInt32((aVal >> 2) & 0x300) | bVal;
    }
    public static void Main()
    {
        uint givenIndex = 192;
		
        for (ushort i = ushort.MinValue;;++i)
        {
            if (givenIndex == getIndex(i))
            {
                Console.WriteLine("Possible input: " + i);
            }
			
            if (i == ushort.MaxValue)
            {
                break;
            }
        }
    }
