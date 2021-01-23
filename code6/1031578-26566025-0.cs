    var continuation = task.ContinueWith(
        t =>
        {
            if (t.IsFaulted)
                Console.WriteLine("Failed");
            else
                Console.WriteLine("Success");
        });
    
    continuation.Wait();
