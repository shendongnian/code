    [Fact]
    public void UsingGeneratorOfDateTime()
    {
        var fixture = new Fixture();
        var generator = fixture.Create<Generator<DateTime>>();
        var sut = fixture.Create<SomeClass>();
        var seed = fixture.Create<int>();
        sut.ExpirationDate =
            generator.First().AddYears(seed);
        sut.ValidFrom =
            generator.TakeWhile(dt => dt < sut.ExpirationDate).First();
        Assert.True(sut.ValidFrom < sut.ExpirationDate);
    }
