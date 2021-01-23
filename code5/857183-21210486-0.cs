    [Theory, AutoData]
    public void All_Birds_Are_Populated( Recipient sut, IFixture fixture)
    {
        fixture.Do( sut.Receive);
    
        Assert.NotNull( sut.Bird1);
        Assert.NotNull( sut.Bird2);
        Assert.NotNull( sut.Bird3);
        Assert.NotNull( sut.Bird4);
    }
