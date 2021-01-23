    [Fact]
    public void Test()
    {
        var fixture = new Fixture();
        fixture.ResidueCollectors.Add(
            new MockRelay(
                new DbSetTypeSpecification()));
        Assert.DoesNotThrow(() => 
            fixture.Create<PriceService>());
    }
