    static void Main(string[] args)
    {
        Console.WriteLine("Program started");
        for (int i = 0; i < 10; i++)
        {
            Boxing();
            Unboxing();
        }
        Console.WriteLine("Program ended");
        Console.Read();
    }
