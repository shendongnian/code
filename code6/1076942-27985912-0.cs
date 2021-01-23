    async Task FooAsync()
    {
      var result = await IsLoginOkAsync();
    }
    public async Task<TokenModel> IsLoginOkAsync();
