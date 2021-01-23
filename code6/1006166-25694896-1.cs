    var actionBlock = new ActionBlock<string>(async address =>
    {
        if (!IsDuplicate(address))
        {
            await LocateAddressAsync(address);
        }
    }, new ExecutionDataflowBlockOptions
    {
        BoundedCapacity = 10000,
        MaxDegreeOfParallelism = Environment.ProcessorCount,
        CancellationToken = new CancellationTokenSource(TimeSpan.FromHours(1)).Token
    });
    await actionBlock.SendAsync(context.Request.UserHostAddress);
