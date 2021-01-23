    void MyMethod() {
      if (Monitor.TryEnter(lockObj)) {
        // Do stuff
        // Release lock
        Monitor.Exit(lockObj);
      } else {
        // We didn't get a lock, crash? Log? 
      }
    }
