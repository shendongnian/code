    var mockDataAccess = new Mock<IProductDataAccess>();
    mockDataAccess
        .Setup(m => m.CreateProduct(It.IsAny<Product>()))
        .Returns(true);
    var productBusiness = new ProductBusiness(mockDataAccess.Object);
    // ... test behaviour here
