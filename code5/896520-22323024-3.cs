    private Product _expiredProduct;
    [TestInitialize]
    public void Setup()
    {      
         _expiredProduct = new Product { Expire = DateTime.Now.AddDays(-1) };
         // etc
    }
    [TestMethod]
    public void Should_not_save_invalid_product()
    {
        var repositoryMock = new Mock<IProductRepository>();        
        var service = new ProductService(repositoryMock.Object);
        flg = service.save(_expiredProduct);
        Assert.False(flg);
        repositoryMock.Verify(r => r.Save(It.IsAny<Product>()),Times.Never());
    }   
