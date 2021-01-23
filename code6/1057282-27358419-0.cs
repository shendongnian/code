    private static async void Async()
    {
        Task taskDelay1 = Task.Run(() => Task.Delay(1000))
                              .ContinueWith(x => Console.WriteLine("One done"));
        Task taskDelay2 = Task.Run(() => Task.Delay(1500))
                              .ContinueWith(x => Console.WriteLine("Two done"));
        Task taskDelay3 = Task.Run(() => Task.Delay(2000))
                              .ContinueWith(x => Console.WriteLine("Three done"));
        await Task.WhenAll(taskDelay1, taskDelay2, taskDelay3);
    }
