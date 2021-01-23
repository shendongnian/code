    var cts = new CancellationTokenSource(5000); // cancel in 5s 
    // Alternatively: cts.CancelAfter(5000);
    try 
    {
        var output = await bufferBlock.ReceiveAsync(cts.Token);
    }
    catch (Exception ex)
    {
        // check if ex is OperationCanceledException,
        // which could be wrapped with AggregateException 
    }
