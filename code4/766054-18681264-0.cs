    protected override void Run()
    {
        var input = Console.ReadKey().KeyChar;
        if (input == 'h')
            Console.Write("This is the help section...");
        else
            Console.Write("Invalid Command.");
        Console.WriteLine(input);
    }
