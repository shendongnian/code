        byte[] buffer = BitConverter.GetBytes(0xfa2);
        if (BitConverter.IsLittleEndian) Array.Reverse(buffer);
        var b = new BitArray(buffer);
        for (int i = 0; i < b.Count; i++)
        {
            char c = b[i] ? '1' : '0';
            Console.Write(c);
        }
        Console.WriteLine();
