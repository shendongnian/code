    var retry = new RetryPolicy(ErrorDetectionStrategy.On<Exception>(), // see http://pastebin.com/6tmQbkj4
                                3, TimeSpan.FromMilliseconds(250));		
    ActionBlock<Tuple<string,byte[],string>> ab  = 
        new ActionBlock<Tuple<string,string,string>>(item => 
            retry.ExecuteAction(() => service.Action(item.Item1, item.Item2, item.Item3)),
            new ExecutionDataflowBlockOptions {
                MaxDegreeOfParallelism = 2
            });
