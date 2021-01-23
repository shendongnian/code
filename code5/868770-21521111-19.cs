    static void Main(string[] args)
    {
        // Get the task.
        var task = Task.Factory.StartNew<int>(() => { return div(32, 0); });
    
        // For error handling.
        task = task.ContinueWith(t => { Console.WriteLine(t.Exception.Message); }, 
            TaskContinuationOptions.OnlyOnFaulted);
    
        // If it succeeded.
        task = task.ContinueWith(t => { Console.WriteLine(t.Result); }, 
            TaskContinuationOptions.OnlyOnRanToCompletion);
    
        Console.ReadKey();
    
        Console.WriteLine("result: " + task.Result); // will crash here
        // you can also check task.Exception
    
        Console.WriteLine("Hello");
    }
