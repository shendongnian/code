    [Test]
    public void YourAsyncMethod_Throws_YourException()
    {
        // Act
        AsyncTestDelegate act = async () => await YourAsyncMethod();
        // Assert
        Assert.That(act, Throws.TypeOf<YourException>());
    }
