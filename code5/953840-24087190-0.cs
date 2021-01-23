    private CancellationTokenSource _cts;
    async void event_handler()
    {
      if (_cts != null)
        _cts.Cancel();
      _cts = new CancellationTokenSource();
      await DoSomethingAsync();
    }
    async Task DoSomethingAsync()
    {
      // change some page's state 
      // change some page's private members
      var someData = await LongOperationAsync(_cts.Token);
      // change some page's state 
      // change some page's private members
    }
