    public async Task Get()
    {
        // Arrange
        HomeController controller = new HomeController();
    
        // Act
        await IHttpActionResult result = controller.Get();
    
        // Assert
        Assert.IsNotNull(result.Content);
    }
