    static void Main(string[] args)
    {
        Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        while (Console.In.Peek() != -1)
        {
            string input = Console.In.ReadLine();
            Console.WriteLine(input);
        }
    }
