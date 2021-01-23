    static void Main(string[] args)
    {
        for (int i = 100; i >0; i--)
        {
            if (i % 10 == 0)
                Console.WriteLine();
            Console.Write(i);                  
        }
        Console.ReadLine();
    }
