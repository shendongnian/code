    static async void StartAndMonitorAsync(Func<Task> taskFunc)
    {
        while (true)
        {
            var task = taskFunc();
            try
            {
                await task;
                // process the result if needed
                return;
            }
            catch (Exception ex)
            {
                // log the error
                System.Console.WriteLine("Error: {0}, restarting...", ex.Message);
            }
            // do other stuff before restarting (if any)
        }
    }
    static private void startLoops()
    {
        System.Console.WriteLine("Starting fizzLoop.");
        StartAndMonitorAsync(() => Task.Factory.StartNew(new Action(fizzLoop)));
        System.Console.WriteLine("Starting buzzLoop.");
        StartAndMonitorAsync(() => Task.Factory.StartNew(new Action(buzzLoop)));
    }
