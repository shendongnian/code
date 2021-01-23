    static void Main(string[] args)
    {
        Task longRunning = Task.Factory.StartNew(Go, TaskCreationOptions.LongRunning);
        while (true)
        {
            Thread.Sleep(1000);
            // this will throw an exception if the task faulted, or simply continue
            // if the task is still running
            longRunning.Wait(0);
        }
    }
    private static void Go()
    {
        Thread.Sleep(4000);
        throw new Exception("Oh noes!!");
    }
