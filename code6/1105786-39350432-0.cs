    var buffer = new BlockingCollection<Task>(maxThreads);
    
    // process while download all threads
    while (!Queue.IsEmpty || buffer.Count > 0)
    {
        SomeClass item;
        while (Queue.TryDequeue(out item))
        {
            var localItem = item;
    
            var localTask = new Task(() =>
            {
                // work with your item
                // in this place you can append Queue    
                buffer.Take(); // free buffer for adding new threads
            });
    
            buffer.Add(localTask);
            localTask.Start();
        }
    
        // in this point Queue is empty,
        // but buffer have remaining thread
        Task.Delay(50).Wait();
    }
