    static void Main(string[] args)
    {
        Task.WhenAll(Task.Run(() => DoSomething()), Task.Run(() => DoSomething())).Wait()
    }
    static void DoSomething()
    {
        for (int i = 0; i < 1000; i++)
            Console.Write("X");
    }
