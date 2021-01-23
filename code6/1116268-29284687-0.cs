    private string GetValueToPrint(CancellationToken token)
    {
       for(int i = 0; i < 10; i++)
       {
           Console.WriteLine("Loop");
           token.ThrowIfCancellationRequested()
           Thread.Sleep(1000);
       }
       return "42";
    }
    
    private void Example()
    {
        var cancellation = new CancellationTokenSource();
        task = Task.Run(() => GetValueToPrint(cancellation.Token), cancellation.Token);
        Thread.Sleep(5000);
        cancellation.Cancel();
    
        bool iscancelled = task.Status == TaskStatus.Canceled;
        Console.WriteLine(iscancelled);
    }
