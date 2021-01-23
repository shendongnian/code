    public void MyFunc()
    {
        var task1 = Task.Run(() => DoWork1());
        var task2 = Task.Run(() => DoWork2());
        
        Task.WaitAll(task1, task2);
        if (task1.Result == task2.Result)
        {
            // ...
        }
        
        Thread.Sleep(syncInterval);
    }
