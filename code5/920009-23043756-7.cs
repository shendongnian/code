    protected void RunMessageLoop()
    {
      while (!_workQueue.IsCompleted)
      {
        Continuation continuation;
        if (_workQueue.TryTake(out continuation))
        {
          continuation.Run();
        }
      }
    }
