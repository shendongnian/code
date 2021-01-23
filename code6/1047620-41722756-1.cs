    // Option A
    [Test]
    public void YourAsyncMethod_Throws_YourException_A()
    {
        // Act
        AsyncTestDelegate act = () => YourAsyncMethod();
        // Assert
        Assert.That(act, Throws.TypeOf<YourException>());
    }
    // Option B (local function)
    [Test]
    public void YourAsyncMethod_Throws_YourException_B()
    {
        // Act
        Task Act() => YourAsyncMethod();
        // Assert
        Assert.That(Act, Throws.TypeOf<YourException>());
    }
