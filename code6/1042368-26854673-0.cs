	public static void Main()
	{        
        StringBuilder str = new StringBuilder();
        byte[] x = { 0xB1, 0x53, 0x63 };
        for (int i = 0; i < 3; i++)
        {
            str.Append(Convert.ToString(x[i], 2).PadLeft(8, '0'));
        }
        Console.WriteLine(str);
        Console.ReadLine();
	}
