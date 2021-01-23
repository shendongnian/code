    [TestMethod]
    public void Get_HeaderIsValid()
    {
        // Arrange
        var controller = new ConfigurationsController(null);
        var controllerContext = new HttpControllerContext();
        var request = new HttpRequestMessage();
        request.Headers.Add("X-My-Header", "success");
    
        // Don't forget these lines, if you do then the request will be null.
        controllerContext.Request = request;
        controller.ControllerContext = controllerContext;
    
        // Act
        var result = controller.Get() as OkNegotiatedContentResult<string>;
    
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Success!", result.Content);
    }
