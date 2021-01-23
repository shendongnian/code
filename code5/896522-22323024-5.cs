    ProductService productService;
    Mock<IProductRepository> repositoryMock;
    [TestInitialize]
    public void Setup()
    {      
        repositoryMock = new Mock<IProductRepository>();
        productService = new ProductService(repositoryMock.Object);
    }
    [TestMethod]
    public void Should_not_save_invalid_product()
    {
        var expiredProduct = new Product { Expire = DateTime.Now.AddDays(-1) };
        bool result = service.save(expiredProduct);
        Assert.False(result);
        repositoryMock.Verify(r => r.Save(It.IsAny<Product>()),Times.Never());
    }
    [TestMethod]
    public void Should_save_valid_product()
    {
        var product = new Product { Expire = DateTime.Now.AddDays(1), Price = 42 };
        repositoryMock.Setup(r => r.Save(product)).Returns(true);
        bool result = service.save(product);
        Assert.True(result);
        repositoryMock.VerifyAll();
    }  
