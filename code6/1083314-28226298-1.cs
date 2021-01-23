    public void MyFunc()
    {
        var task1 = Task.Run(() => DoWork1());
        var result2 = DoWork2();
        
        if (task1.Result == result2)
        {
            // ...
        }
        
        Thread.Sleep(syncInterval);
    }
