        var b = new BitArray(BitConverter.GetBytes(0xfa2));
        for (int i = b.Count-1; i >= 0; i--)
        {
            char c = b[i] ? '1' : '0';
            Console.Write(c);
        }
        Console.WriteLine();
