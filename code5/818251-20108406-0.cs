    TransformBlock<MyObject, MyObject> myProcessingBlock = new ActionBlock<MyObject, MyObject>(
       myObject =>
       {
         // ... perform your processing of this object here ...
         return myObject;
       },
       new ExecutionDataflowBlockOptions
       {
          MaxDegreeOfParallelism = 20
       });
    ActionBlock<MyObject> myUINotificationBlock = new ActionBlock<MyObject>(
       myObject =>
       {
           // ... update the UI details for this data here ...
       },
       new ExecutionDataflowBlockOptions
       {
           TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext() // must be executed on the Dispatcher block!
       });
     myProcessingBlock.LinkTo(myUINotificationBlock);
