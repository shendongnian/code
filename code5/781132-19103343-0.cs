    Task<SomeResult> DoSomethingAsync()
    {
        using (var foo = new Foo())
        {
            return foo.DoAnotherThingAsync();
        }
    }
    async Task<SomeResult> DoSomethingAsync()
    {
        using (var foo = new Foo())
        {
            return await foo.DoAnotherThingAsync();
        }
    }
