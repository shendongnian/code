    [Fact]
    public async Task repro()
    {
        var scheduler = new TestScheduler();
        var countObs = Observable
            .Return(1)
            .Select(i => Observable.FromAsync(Whatever))
            .Concat()
            //.ObserveOn(scheduler) // serves no purpose in this test
            .Count();
        Assert.Equal(0, count);
        //scheduler.Start(); // serves no purpose in this test.
        var count = await countObs;
        Assert.Equal(1, count);
    }
