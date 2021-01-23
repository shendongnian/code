    [Fact]
    public void PassByMovingAutoMoqRelay()
    {
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        var relay = fixture.ResidueCollectors.OfType<MockRelay>().Single();
        fixture.Customizations.Add(relay);
    
        var sut = fixture.Create<MyClass>(); // Doesn't throw
    }
