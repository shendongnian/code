    [Test]
    public void Sum_Is_Zero_When_Null_Collection()
    {
        var bomManager = new BomManager();
        Assert.AreEqual(0, bomManager.MethodToTest(null));
    }
