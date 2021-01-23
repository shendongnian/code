    TransformBlock<MyObject, MyObject> myProcessingBlock = new ActionBlock<MyObject, MyObject>(
       async myObject =>
       {
         HttpClient someHttpClient = new HttpClient();
         HttpResponseMessage responseMessage = await someHttpClient.PostAsync(..., ...);
         return myObject;
       },
       new ExecutionDataflowBlockOptions
       {
          MaxDegreeOfParallelism = 20
       });
