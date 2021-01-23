    Task continuation = task.ContinueWith(t => 
    {
        Console.WriteLine("Task faulted");
        AggregateException ae = t.Exception;
        ae.Flatten().Handle(ex =>
        {
            if (typeof(InvalidOperationException) == ex.GetType())
            {
                Console.WriteLine("InvalidOperationException handled --> " + ex.Message);
                return true;
            }
            return false;
        });
    }, TaskContinuationOptions.OnlyOnFaulted);
    task.Start();
    Thread.Sleep(2000);
    continuation.Wait();
