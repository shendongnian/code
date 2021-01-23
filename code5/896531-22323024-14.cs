    ProductService service;
    Mock<IProductRepository> repositoryMock;
    Mock<Product> productMock;
    [TestInitialize]
    public void Setup()
    {      
        repositoryMock = new Mock<IProductRepository>();
        service = new ProductService(repositoryMock.Object);
        productMock = new Mock<Product>();
    }
    [TestMethod]
    public void Should_not_save_invalid_product()
    {
        productMock.SetupGet(p => p.IsValid).Returns(false);
        bool result = service.save(productMock.Object);
        Assert.False(result);
        repositoryMock.Verify(r => r.Save(It.IsAny<Product>()),Times.Never());
    }
    [TestMethod]
    public void Should_save_valid_product()
    {
        productMock.SetupGet(p => p.IsValid).Returns(true); 
        repositoryMock.Setup(r => r.Save(productMock.Object)).Returns(true);
        bool result = service.save(productMock.Object);
        Assert.True(result);
        repositoryMock.VerifyAll();
    }  
