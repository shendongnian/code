    public static void Count()
    {
        int written = int.Parse(Console.ReadLine());
        for (int i = written % 2; i <= written; i += 2)
        {
            Console.WriteLine(i);
        }
    }
