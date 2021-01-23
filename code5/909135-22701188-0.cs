    public async Task SetupDatabaseAsync()
    {
      await CreateTableAsync<Session>();
      await CreateTableAsync<Speaker>();
    }
    Task.WaitAll(SetupDatabaseAsync());
