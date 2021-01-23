    protected override void OnStop()
    {
      this.RequestAdditionalTime(100000); // some large number        
      _cancelSource.Cancel();     
      TraceMessage("Task cancellation requested."); // Last thing traced
      try
      {
        bool allStopped = this.AllJobsCompleted.GetAwaiter().GetResult();          
        TraceMessage(string.Format("allStopped = '{0}'.", allStopped));
      }
      catch (Exception e)
      {
        TraceMessage(e.Message);
      }
    }
