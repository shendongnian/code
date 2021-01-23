    static void Main(string[] args)
    {
        var tasks = new List<Task>();
        var completed = 0;
        var cts = new CancellationTokenSource();
    
        for (int i = 0; i < 100; i++)
        {
            tasks.Add(Task.Run(async () =>
            {
                await Task.Delay(1000, cts.Token);
                Console.WriteLine("Completed task {0}", i);
                completed++;
            }, cts.Token));
        }
    
        Extensions.WhenN(tasks, 30, cts).Wait();
    
        Console.WriteLine(completed);
    
        Console.ReadLine();
    }
