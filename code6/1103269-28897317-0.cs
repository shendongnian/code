    [Fact]
    public void AutoFixtureAlreadySupportsTasks()
    {
        var fixture = new Fixture();
        var t = fixture.Create<Task<IEnumerable<int>>>();
        Assert.NotEmpty(t.Result);
    }
