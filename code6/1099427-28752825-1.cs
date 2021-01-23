    protected Task OnDataChangedAsync(Journaling.Action a)
    {
      var handler = DataChanged;
      if (handler == null)
        return Task.FromResult<object>(null); // or TaskConstants.Completed
      var deferrals = new DeferralManager();
      var args = new Journaling.DataChangeEventArgs(deferrals, a);
      handler(args);
      return deferrals.SignalAndWaitAsync();
    }
