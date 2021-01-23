    public async Task GetCustomersAsync(CancellationToken token)
    {
      for (int i = 0; i < 99; i++)
      {
        token.ThrowIfCancellationRequested();
        customers = await customerRequest.GetCustomersAsync(token);
      }
    }
