    async Task GetCreditHistoryOnBackgroundThreadAsync(string ssn)
    {
      try
      {
        var history = await Task.Run(() => GetCreditHistory(ssn));
        // Update UI with credit history.
      }
      catch (Exception ex)
      {
        // Update UI with error details.
      }
    }
