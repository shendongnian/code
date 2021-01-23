    // Create a list of the mapped values you're expecting
    var productModels = new List<ProductModel> {
        new ProductModel { Id=11,name="eleven"},
        new ProductModel { Id=12,name="twelve"},
        new ProductModel { Id=13,name="thirteen"}
    };
    // Mock the IMappingEngine
    var engine = new Mock<IMappingEngine>();
    // Create a variable to count the calls
    var calls=0;
    // Mock ALL calls to map, where the destination is ProductModel
    // and source is Product
    engine.Setup(m => m.Map<ProductModel>(It.IsAny<Product>()))
          .Returns(()=>productModels[calls]) // Return next productModel
          .Callback(()=>calls++)   // Increment counter to point to next model
