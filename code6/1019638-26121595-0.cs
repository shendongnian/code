    static void Main(string[] args)
    {
        Task operation = Task.Factory.StartNew(() => Console.WriteLine("Prepare"))
            .Then(_ => WorkAsync())
            .Select(resultTask => Console.WriteLine(resultTask.Result));
        operation.Wait();
        Console.ReadLine();
    }
    private static Task<string> WorkAsync()
    {
        return DelayedTask.Delay(TimeSpan.FromMilliseconds(1500))
            .Select(_ => "See my results...");
    }
