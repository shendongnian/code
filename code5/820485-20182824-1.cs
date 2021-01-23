    private ICommand myCommand;
    public ICommand MyCommand
    {
      get { return myCommand ?? (myCommand = new AsyncRelayCommand(p => Task.Factory.StartNew(doStuff))); }
    }
    private void doStuff()
    {
      System.Threading.Thread.Sleep(5000);
    }
