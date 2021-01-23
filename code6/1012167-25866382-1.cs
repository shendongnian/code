	public void Can_Sell_Given_Quantity_Of_Single_Products_Stock_Quantity()
	{
		// Arrange
		int stockQuantity = 10;
		int quantityToSell = 4;
		int newQuantity = 6;
		
		var productMock = new Mock<Product>(MockBehavior.Strict);
		productMock.SetupGet(p => p.StockQuantity).Returns(stockQuantity);
		productMock.SetupSet(p => p.StockQuantity = newQuantity);
		
		var classUnderTest = new SellBuyPipeLine();
			
		// Act
		test.SellGivenQuantityOfProduct(product, quantityToSell);
		
		// Assert
		productMock.VerifySet(p => p.StockQuantity, Times.Once());
	}
