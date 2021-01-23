    [Theory, Autodata]
    public void All_Birds_Are_Populated(
        CallingBird bird1,
        CallingBird bird2,
        CallingBird bird3,
        CallingBird bird4,
        Recipient sut)
    {
        sut.Receive(bird1, bird2, bird3, bird4);
    
        Assert.NotNull(sut.Bird1);
        Assert.NotNull(sut.Bird2);
        Assert.NotNull(sut.Bird3);
        Assert.NotNull(sut.Bird4);
    }
