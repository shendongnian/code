    var task = filteredStream.StartStreamMatchingAllConditionsAsync();
                
    while (true)
    {
        Thread.Sleep(500);
        if (task.IsCanceled || task.IsCompleted || task.IsFaulted)
        {
            break;
        }
        if (ShouldStop)
        {
             filteredStream.StopStream();
             break;
        }
    }
    task.Wait();
