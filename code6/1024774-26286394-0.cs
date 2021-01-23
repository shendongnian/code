    public async Task SomeFunc() {
      // Wrapper code
      Task myTask = MyMethod1;
      // Do stuff
      await myTask;
    }
    private async Task myMethod1() {
       CloudQueueMessage message = await myCloudQueue.GetMessageAsync();
       // do stuff
    }
