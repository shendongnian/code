	[Test]
	public void Index_ReportsModelError_WhenProductAlreadyExists()
	{
		const int ExistingProductNumber = 10;
		var _productsService = new Mock<IProductsService>();
		var existingProduct = new Product { ProductNumber = ExistingProductNumber };
		_productsService.Setup(m => m.GetAll(true)).Returns(new [] { existingProduct });
		
		controller.Index(new ProductModel { ProductNumber = ExistingProductNumber });
		// Assert
	}
