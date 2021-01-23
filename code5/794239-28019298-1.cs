    var step2 = new ActionBlock<int>(i => {
        Thread.Sleep(i);
        Console.WriteLine(@"* 2: ID = " + i);
    }, new ExecutionDataflowBlockOptions {
        MaxDegreeOfParallelism = 1,
        //MaxMessagesPerTask = 1
    });
    
    var random = new Random();
    var tasks = Enumerable.Range(1, 50).Select(p => {
        return Task.Factory.StartNew(() => {
            var timeout = random.Next(5, p * 50);
            Thread.Sleep(timeout / 2);
            Console.WriteLine(@"  1: ID = " + p);
            return p;
        }).ContinueWith(t => {
            Thread.Sleep(t.Result);
            step2.Post(t.Result);
        });
    }).ToArray();
    
    await Task.WhenAll(tasks).ContinueWith(t => step2.Complete());
    await step2.Completion;
