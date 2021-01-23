    [Fact]
    public void SimplestCustomization()
    {
        var fixture = 
            new Fixture().Customize(new AutoConfiguredMoqCustomization());
        var svc = fixture.Create<ISomeService>();
        Assert.NotEmpty(svc.Get().Result);
    }
