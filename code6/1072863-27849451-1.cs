    [TestMethod]
    public void stockCodeIsNullOrEmpty()
    {
        ICustomerRepository testRepository = //create a test repository here
        //Arrange
        var x = new PartInvoiceController(testRespository);
    
        //Act
        bool result = x.CreatePartInvoice("", 1, "test").Success;
    
        //Assert
        Assert.AreEqual(result, false);
    }
