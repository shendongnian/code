    public async void LoadData()
    {
      try
      {
        ... // Set up "loading" UI state.
        var balance = await GetBalanceAsync();
        ... // Set up "normal" UI state.
        Balance = balance;
      }
      catch
      {
        ... // Set up "error" UI state.
      }
    }
