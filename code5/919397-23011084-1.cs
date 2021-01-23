    [Test]
    public async Task Test()
    {
        var sut = new Consumer();
        var results = sut.Trigger();
        var result = await results.FirstAsync();
    }
