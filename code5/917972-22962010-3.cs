      private ProductController controller;
      private Mock<IProductService> productServiceMock;
      private Mock<ICategoryService> categoryServiceMock;
      [SetUp]
      public void Setup()
      {
          productServiceMock = new Mock<IProductService>();
          categoryServiceMock = new Mock<ICategoryService>();
          controller = new ProductController(productServiceMock.Object,
                                             categoryServiceMock.Object);
      }
