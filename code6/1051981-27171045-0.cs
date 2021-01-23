    var printSolution = new ActionBlock<int>(input =>
    {
        Console.WriteLine("Solution: {0} @ {1}", input, watch.Elapsed.TotalMilliSeconds);
    },executionDataflowBlockOptions);
    
    var plus10 = new ActionBlock<int>(async input =>
    {
        if (input == 2)
        {
            await Task.Delay(5000);
        }
        Console.WriteLine("Exiting plus10 for input {0} @ {1}", input, watch.Elapsed);
        await printSolution.SendAsync(input + 10);
    }, executionDataflowBlockOptions);
   
    
