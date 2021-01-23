    public Task<T> GetDataAsync<T>(string operation)
    {
      // Check cache for data first
      var task = HttpRuntime.Cache[operation] as Task<T>;
      if (task != null)
        return task;
      task = DoGetDataAsync(operation);
      AddToCache(operation, task);
      return task;
    }
    private async Task<T> DoGetDataAsync<T>(string operation)
    {
      // Get data from remote api
      using (HttpClient client = new HttpClient())
      {
        client.BaseAddress = new Uri("https://myapi.com/");
        var response = await client.GetAsync(operation);
        return (await response.Content.ReadAsAsync<T>());
      }
    }
