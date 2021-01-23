    [TestMethod]
    public void GetReturnsProduct()
    {
        // Arrange
        var username = "username@example.com"
        var user = new ClaimsPrincipal(new CustomIdentity(username));
        var controller = new ProductsController(repository);
        controller.Request = new HttpRequestMessage();
        controller.Configuration = new HttpConfiguration();
        controller.User = user;
        
        // Act
        var response = controller.Get(10);
    
        // Assert
        Product product;
        Assert.IsTrue(response.TryGetContentValue<Product>(out product));
        Assert.AreEqual(10, product.Id);
    }
