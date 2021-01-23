    class LogMethodCallAttribute : OnMethodBoundaryAspect
    {
        Task task;
        ... as before ...
  
        public override void OnEntry(MethodExecutionArgs args)
        {
            ...
            task = Task.Factory.StartNew(...);
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            exitTime = DateTime.Now;
            // Wait for the task to have completed...
            task.Wait();
            // Now you can use the fields
        }
    }
