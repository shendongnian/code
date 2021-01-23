    async Task<string> MyMethodAsync()
    {
      Contacts cons = new Contacts();
      var searchResults = await cons.SearchTaskAsync(String.Empty, FilterKind.None);
      string result = SomeOtherSynchronousOperation(searchResults);
      await DoOtherStuffWithResult(result);
      return result;
    }
