    [TestInitialize]
    public void Setup()
    {
        // This function will be executed before each test.
        // Use this function as an opportunity to clear any shared objects e.g.
        // dbContext <- Delete all data that is not required.
    }
    
    [TestMethod]
    public void Test1()
    {
        // Arrange.
        // Add 1 item to the dbContext
    
        // Act
        var actual = _ws.GetAllItems();
    
        // Assert.
        Assert.AreEqual(1, actual.Count());
    }
    
    [TestMethod]
    public void Test2()
    {
        // Arrange.
        // Here, the dbContext will have been cleared in the Setup() function.
        // Add 5 items to the dbContext
    
        // Act
        var actual = _ws.GetAllItems();
    
        // Assert.
        Assert.AreEqual(5, actual.Count()); // Total items should be 5, not 6.
    }
