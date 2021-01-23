    private static void Main(string[] args)
    {
        IMyService testService;
        testService = new MyServiceA();
        Console.WriteLine(testService.Name);   // prints 'A'
        testService = new MyServiceB();
        Console.WriteLine(testService.Name);   // prints 'B'
        Console.ReadLine();
    }
