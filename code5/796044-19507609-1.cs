    private Task RaiseMyEventAsync()
    {
      var handler = MyEvent;
      if (handler == null)
        return Task.FromResult<object>(null); // or TaskConstants.Completed
      var args = new MyEventArgs(...);
      handler(args);
      return args.WaitForDeferralsAsync();
    }
