    // The dataflow network
    BufferBlock<Master> masterBuffer = null;
    TransformManyBlock<Master, Detail> masterTransform = null;
    TransformBlock<Detail, object> detailTransform = null;
    ActionBlock<Tuple<IList<object>, IList<object>>> batchAction = null;
    
    // Buffer master records to enable efficient throttling.
    masterBuffer = new BufferBlock<Master>(new DataflowBlockOptions { BoundedCapacity = 1 });
    // Sequentially transform master records into a stream of detail records.
    masterTransform = new TransformManyBlock<Master, Detail>(async masterRecord =>
    {
        var records = await StoredProcedures.GetObjectsAsync(masterRecord);
        // Filter the master records based on some criteria here
        var filteredRecords = records;
        // Only propagate completion to the last batch
        var propogateCompletion = masterBuffer.Completion.IsCompleted && masterTransform.InputCount == 0;
        // Create a batch join block to encapsulate the results of the master record.
        var batchjoinblock = new BatchedJoinBlock<object, object>(records.Count(), new GroupingDataflowBlockOptions { MaxNumberOfGroups = 1 });
        // Add the batch block to the detail transform pipeline's link queue, and link the batch block to the the batch action block.
        detailTransform.LinkTo(batchjoinblock.Target1, detailResult => detailResult is Detail);
        detailTransform.LinkTo(batchjoinblock.Target2, detailResult => detailResult is Exception);
        batchjoinblock.LinkTo(batchAction, new DataflowLinkOptions { PropagateCompletion = propogateCompletion });
        return filteredRecords;
    }, new ExecutionDataflowBlockOptions { BoundedCapacity = 1 });
    // Process each detail record asynchronously, 150 at a time.
    detailTransform = new TransformBlock<Detail, object>(async detail => {
        try
        {
            // Perform the action for each detail here asynchronously
			await DoSomethingAsync();
			
            return detail;
        }
        catch (Exception e)
        {
            success = false;
            return e;
        }
    }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 150, BoundedCapacity = 300 });
    // Perform the proper action for each batch
    batchAction = new ActionBlock<Tuple<IList<object>, IList<object>>>(async batch =>
    {
        var details = batch.Item1.Cast<Detail>();
        var errors = batch.Item2.Cast<Exception>();
        // Do something with the batch here
    }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 4 });
    masterBuffer.LinkTo(masterTransform, new DataflowLinkOptions { PropagateCompletion = true });
    masterTransform.LinkTo(detailTransform, new DataflowLinkOptions { PropagateCompletion = true });
