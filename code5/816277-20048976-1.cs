    var taskp = Task.Factory.StartNew(() =>
    {
        var task1 = Task.Factory.StartNew(() =>
        {
            Thread.Sleep(1000);
            return "dummy value 1";
        }).ContinueWith((continuation) => { Console.WriteLine("task1"); });
    
        var task2 = Task.Factory.StartNew(() =>
        {
            Thread.Sleep(3000);
            return "dummy value 2";
        }).ContinueWith((continuation) => { Console.WriteLine("task2"); });
    
        var task3 = Task.Factory.StartNew(() =>
        {
            Thread.Sleep(2000);
            return "dummy value 3";
        }).ContinueWith((continuation) => { Console.WriteLine("task3"); });
    
        Task.Factory.ContinueWhenAll(new Task[] { task1, task2, task3}, (x) => { Console.WriteLine("Main Task Complete"); });
    });            
