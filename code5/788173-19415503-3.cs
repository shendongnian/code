     [TestMethod]
     public void IndexGetsAllProducts()
     {
            //Arrange 
            var fakeProductRepo = new FakeProductsRepository();
            var productsController = new ProductsController(fakeProductRepo);
            //Act
            var result = productsController.Index(1) as ViewResult;
            //Assert
            var model = result.Model as List<Product>;
            Assert.AreEqual(2, model.Count);
     }
