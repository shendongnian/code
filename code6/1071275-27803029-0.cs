    private AsyncContextThread _mainThread = new AsyncContextThread();
    protected override void OnStart(string[] args)
    {
      _mainThread = new AsyncContextThread();
      _mainThread.Factory.Run(async () =>
      {
        string abd = "Tariq";
        await ConnectAsync();
        HubProxy.Invoke("Send", UserName, abd);
      });
    }
    private async Task ConnectAsync()
    {
      ...
    }
