    [Theory, AutoData]
    public void UsingGeneratorOfDateTimeDeclaratively(
        Generator<DateTime> generator,
        SomeClass sut,
        int seed)
    {
        sut.ExpirationDate =
            generator.First().AddYears(seed);
        sut.ValidFrom = generator
            .TakeWhile(dt => dt < sut.ExpirationDate).First();
        Assert.True(sut.ValidFrom < sut.ExpirationDate);
    }
