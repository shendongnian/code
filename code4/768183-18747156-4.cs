     // Create an ActionBlock that performs some work. 
     var workerBlock = new ActionBlock<MessageData>(
      data=>
         {
             DoWork(data); // method consuming data
         },
      // Specify a maximum degree of parallelism. 
      new ExecutionDataflowBlockOptions
      {
         MaxDegreeOfParallelism = maxDegreeOfParallelism
      });
  
    // Post messageCount messages to the queue
    for (int i = 0; i < messageCount; i++)
     {
       var messageData = new MessageData();
       workerBlock.Post(messageData);
     }
     // Signal that Producer has no more data to send
     workerBlock.Complete();
     // Wait for all messages to propagate through the network.
     workerBlock.Completion.Wait();
