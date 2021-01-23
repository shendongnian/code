    private Task _task; // have a local task variable
    
    // move your work here, effectively what you have in Task.Factory.StartNew(...)
    public void SetupWork()
    {
        task = new Task (/*your work here*/);
        // see, I don't start this task here
        // ...
    }
    // Call this when you need to start/restart work
    public void RunWork()
    {
        task.Run();
    }
  
