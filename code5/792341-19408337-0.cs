    public async Task MethodCAsync() { await MethodDAsync(); // some code after  } 
    public async Task MethodDAsync() { await MethodEAsync(); // some code after  } 
    async Task MethodKAsync()
    {
      await Save();
    }
