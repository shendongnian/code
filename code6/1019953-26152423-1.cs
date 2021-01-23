    [Test]
    public void Sum_Is_Zero_When_No_Entries()
    {
        var bomManager = new BomManager();
        Assert.AreEqual(0, bomManager.MethodToTest(new Collection<int>()));
    }
