    public Task<IAsyncEnumerator<StreamResult<Foo>>> Get()
    {
        var query = AsyncDocumentSession.Query<Foo, FooIndex>();
        return AsyncDocumentSession.Advanced.StreamAsync(query);
    }
