    // Arrange
    // - create the mock repository
    Mock<IProductRepository> mock = new Mock<IProductRepository>();
    mock.Setup(m => m.Products).Returns(new Product[] {
        new Product {ProductID = 1, Name = "P1", Category = "Apples"},
        new Product {ProductID = 4, Name = "P2", Category = "Oranges"},
    }.AsQueryable());
    // Arrange - create the controller
    NavController target = new NavController(mock.Object);
    // Arrange - define the category to selected
    string categoryToSelect = "Apples";
    // Action
    string result = (ViewResult)target.Menu(categoryToSelect);
    // Assert
    Assert.AreEqual(categoryToSelect,result.Model);
