    void Main()
    {
        Task.Factory.StartNew(() =>
        {
            // wait for 5 seconds or user hit Enter key cancel the task
            Thread.Sleep(5000);
            Console.WriteLine("Task done!");
        });
    
        Console.WriteLine("Here's the main thread.");
    
        Console.Read();
    }
