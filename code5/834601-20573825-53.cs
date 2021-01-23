    public async Task Example()
    {
        Foo();
        string barResult = await BarAsync();
        Baz(barResult);
    }
