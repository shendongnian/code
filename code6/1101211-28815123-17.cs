    [TestMethod]
    public void TestGetCompanyList()
    {
        //Arrange
        var config = new TestConfiguration(){ Setting1 = "mysetting" };
        var accountController = new AccountServiceController(config);
    }
