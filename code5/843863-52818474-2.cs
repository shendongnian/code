    static void Main(string[] args)
    {
        Console.WriteLine("Foo called");
        var result = Foo(5);
        while (result.Status != TaskStatus.RanToCompletion)
        {
            Console.WriteLine("Thread ID: {0}, Status: {1}", Thread.CurrentThread.ManagedThreadId, result.Status);
            Task.Delay(100).Wait();
        }
        Console.WriteLine("Result: {0}", result.Result);
        Console.WriteLine("Finished.");
        Console.ReadKey(true);
    }
    private static Task<string> Foo(int seconds)
    {
        return Task.Run(() =>
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.WriteLine("Thread ID: {0}, second {1}.", Thread.CurrentThread.ManagedThreadId, i);
                Task.Delay(TimeSpan.FromSeconds(1)).Wait();
            }
            return "Foo Completed.";
        });
    }
