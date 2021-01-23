    private static async void WatchForUnobservedExceptions()
    {
        TaskScheduler.UnobservedTaskException += (sender, e) =>
        {
            throw new Exception("An Exception occurred in a Task but was not observed", e.Exception.InnerException);
        };
    
        //This polling loop is necessary to ensure the faulted Task's finalizer is called (which causes UnobservedTaskException to fire) in a timely fashion
        while (true)
        {
            Console.WriteLine("Heartbeat");
            GC.Collect();
            await Task.Delay(5000);
        }
    }
