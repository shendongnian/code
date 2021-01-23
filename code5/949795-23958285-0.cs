    public async Task<List<Location>> Get()
    {
      var result = new List<Location>();
      var query = AsyncDocumentSession.Query<Foo, FooIndex>();
      using (var enumerator = await AsyncDocumentSession.Advanced.StreamAsync(query))
        while (await enumerator.MoveNextAsync())
          result.Add(enumerator.Current.Document);
      return result;
    }
