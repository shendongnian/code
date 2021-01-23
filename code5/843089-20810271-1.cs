    [Fact]
    public void ResponseIsCorrect()
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(new RsvpBuilder());
        var sut = fixture.Create<Rsvp>();
            
        var actual = sut.Response;
        Assert.Equal("Attending", actual);
    }
