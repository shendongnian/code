    public void SomeMethodThatDoesSomethingOnABackgroundThread()
    {
      ThreadPool.QueueUserWorkItem(() => 
      { 
        // Do some operation that is going to take some time, or can't be done on the UI thread.
        Thread.Sleep(100000); 
        // Operation is complete, let's return the result back to the UI.
        CurrentSynchronizationContext.Post(() => 
        {
          // Change the UI, send a messagebox to the user, change the image. Whatever you need.
          // Also the return isn't necessary, it's just signifying that the method is done. 
          return; 
        }); 
      }
    }
