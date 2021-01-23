    public async Task DownloadTask()
    {
       Task[] tasks = new Task[2];
       tasks[0] = DoSomeStuff();
       tasks[1] = DoSomeStuff();
       await Task.WhenAll(tasks);
    }
