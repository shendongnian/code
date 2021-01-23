    [TestMethod]
    public void GetProduct_ShouldReturnCorrectProduct()
    {
        var testProducts = GetTestProducts();
        var controller = new SimpleProductController(testProducts);
        var result = controller.GetProduct(4) as OkNegotiatedContentResult<Product>;
        Assert.IsNotNull(result);
        Assert.AreEqual(testProducts[3].Name, result.Content.Name);
    }
