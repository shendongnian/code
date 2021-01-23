    [TestMethod]
    public void Get()
    {
        //Arrenge
        var controller = new HomeController();
        //Act
        var result = controller.Get().Result as HtmlActionResult;
        //Assert
        Assert.IsNotNull(result);
    }
