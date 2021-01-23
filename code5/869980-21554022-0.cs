    private readonly SemaphoreSlim _mutex = new SemaphoreSlim(1);
    public async Task UploadCurrentXMLAsync()
    {
      await _mutex.WaitAsync();
      try
      {
        ...
        var query = ParseObject.GetQuery("RANDOM_TABLE").WhereEqualTo("some_field",  "string");
        var count = await query.CountAsync();
        ParseObject temp_A;
        temp_A = await query.FirstAsync();
        ...
        // do lots of stuff
        ...
        await temp_A.SaveAsync();
      }
      finally
      {
        _mutex.Release();
      }
    }
