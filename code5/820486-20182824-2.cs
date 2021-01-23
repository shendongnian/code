    private ICommand myCommand2;
    public ICommand MyCommand2
    {
      get { return myCommand2 ?? (myCommand2 = new AsyncRelayCommand(p => doStuff2())); }
    }
    private async Task doStuff2()
    {
      await Task.Delay(5000);
    }
