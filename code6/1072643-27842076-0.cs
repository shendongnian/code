    var block = new ActionBlock<MyRecord>(
        rec => ProcessRecord(rec), 
        new ExecutionDataflowBlockOptions{MaxDegreeOfParallelism = 20});
    
    while ((rec = GetNextRecord()) != null)
    {
         block.Post(rec);
    }
    
    block.Complete();
    await block.Completion
