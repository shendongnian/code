    private static void Main(string[] args)
    {
        Task task = Task.Run(DoSomething);
        Console.WriteLine("test");
        task.Wait();
        Console.Read();
    }
    static void DoSomething()
    {
        // Code to run on a separate thread
    }
