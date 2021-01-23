    var options = new ExecutionDataflowBlockOptions {
    	MaxDegreeOfParallelism = 4,
    	SingleProducerConstrained = true
    };
    
    var actionBlock = new ActionBlock<int>(i => {
    	Console.WriteLine("Running index {0,3} : {1}", i, DateTime.Now.ToString("HH:mm:ss.fff"));
    	System.Threading.Thread.Sleep(i < 10 ? 1000 : 10);
    }, options);
    			
    Task.WhenAll(Enumerable.Range(0, 40).Select(actionBlock.SendAsync)).Wait();
    actionBlock.Complete();
    actionBlock.Completion.Wait();
