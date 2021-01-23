    [TestMethod]
    public void Can_Sell_Given_Quantity_Of_Single_Products_Stock_Quantity()
    {
        var product = new Product { ArticleNr = 87, StockQuantity = 10 };
        var pipeline = new SellBuyPipeLine();
        pipeline.SellGivenQuantityOfProduct(product, 5);
        Assert.AreEqual(5, product.StockQuantity);
    }
