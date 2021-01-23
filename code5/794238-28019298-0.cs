    var taskFactory = new TaskFactory(TaskScheduler.Defau
    
    var random = new Random();
    var tasks = Enumerable.Range(1, 30).Select(p => {
        return taskFactory.StartNew(() => {
            var timeout = random.Next(5, p * 50);
            Thread.Sleep(timeout / 2);
            Console.WriteLine(@"  1: ID = " + p);
            return p;
        }).ContinueWith(t => {
            Console.WriteLine(@"* 2: ID = " + t.Result);
        }, TaskContinuationOptions.ExecuteSynchronously);
    }).ToArray();
    
    Task.WaitAll(tasks);
