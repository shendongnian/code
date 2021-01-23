    [Fact]
    public void TestMethod()
    {
        AssertAsync.CompletesIn(2, () =>
        {
            RunTaskThatMightNotComplete();
        });
    }
