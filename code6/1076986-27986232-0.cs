    internal async void CheckServiceConnection()
    {
      var result = await _da.CheckServiceConnection();
      GeneralEventArgs args = new GeneralEventArgs();
      args.GeneralObject = result;
      ServiceConnection(this, args);
    }
