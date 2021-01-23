    // One off initialisation somewhere at class scope
    private static ManualResetEventSlim taskRunning = new ManualResetEventSlim();
    private static object taskLock = new Object();
    // code called from the timer, do in a lock to avoid race conditions with two
    // or more threads call this.
    lock (taskLock) {
      if (!taskRunning.IsSet) {
        StartTheTask(); // assuming this does not return until task is running.
      }
    }
    // At the outermost scope of the code in the task:
    try {
      Debug.Assert(!taskRunning.IsSet); // Paranoia is good when doing threading
      taskRunning.Set();
      // Task impementation
    } finally {
      Debug.Assert(taskRunning.IsSet); // Paranoia is good when doing threading
      taskRunning.Reset();
    }
