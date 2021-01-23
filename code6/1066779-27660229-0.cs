      var t = new Task(Initialize);
      t.Start();
      while (!t.IsCompleted && !t.IsFaulted)
      {
        // Do other work in the main thread
      }
      if (t.IsFaulted)
      {
        if (t.Exception != null)
        {
          if(t.Exception.InnerException != null)
            throw t.Exception.InnerException;
        }
        throw new InvalidAsynchronousStateException("Initialization failed for an unknown reason");
      }
