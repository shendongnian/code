        ...
        
        // Start async.
        var task1 = Task.Factory.StartNew(Accept, s1);
        var task2 = Task.Factory.StartNew(Accept, s2);
    
        Task.WhenAll(task1, task2).Wait();    
    
        Log("Nothing left to do, stopping service.");
    }
