    [Fact]
    public void ConfigureMock()
    {
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        fixture.Freeze<Mock<ISomeService>>()
            .Setup(s => s.Get())
            .Returns(fixture.Create<Task<IEnumerable<int>>>());
        var svc = fixture.Create<ISomeService>();
            
        Assert.NotEmpty(svc.Get().Result);
    }
