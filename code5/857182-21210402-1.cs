    [Theory, Autodata]
    public void All_Birds_Are_Populated(
        Generator<CallingBird> g,
        Recipient sut)
    {
        var birds = g.Take(4).ToList();
        sut.Receive(birds[0], birds[1], birds[2], birds[3]);
    
        Assert.NotNull(sut.Bird1);
        Assert.NotNull(sut.Bird2);
        Assert.NotNull(sut.Bird3);
        Assert.NotNull(sut.Bird4);
    }
