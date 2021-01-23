    var block = new ActionBlock<CustomObject>(
        item => CallWebServiceAsync(item), 
        new ExecutionDataflowBlockOptions
        {
            MaxDegreeOfParallelism = 5,
            BoundedCapacity = 1000
        });
        
    foreach (CustomObject value in values)
    {
        await block.SendAsync(value);
    }
    block.Complete();
    await block.Completion;
