    [Fact]
    public void SimplestThingThatCouldPossiblyWork()
    {
        var fixture = new Fixture();
        var expectedCity = "foo";
        var person = fixture.Create<Person>();
        person.Address.City = expectedCity;
        Assert.Equal(expectedCity, person.Address.City);
    }
