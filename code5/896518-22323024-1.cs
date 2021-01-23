    [TestMethod]
    public void Should_not_save_invalid_product()
    {
        var repositoryMock = new Mock<IProductRepository>();        
        var service = new ProductService(repositoryMock.Object);
        // create helper method to create product stubs
        var expiredProduct = new Product { Expire = DateTime.Now.AddDays(-1) };
        flg = service.save(product);
        Assert.False(flg);
    }
