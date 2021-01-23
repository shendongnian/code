    ProductV1Controller _productController;
    Mock<IProductRepository> _mockRepository;
    [TestInitialize]
    public void TestInitialize()
    {
        _mockRepository = new Mock<IProductRepository>();
        _productController = new ProductV1Controller(_mockRepository.Object);
    }
    [TestMethod]
    public void ShouldLoadAllProducts()
    {       
        _mockRepository.Setup(r => r.GetProducts()).Return(SomeProducts);
        var returnedProducts = _productController.GetProducts();
        Assert.Equals(returnedProducts, SomeProducts);
        _mockRepository.VerifyAll();
    }
