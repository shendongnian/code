        [TestMethod]
        public void Can_Get_Stock()
        {
            // arrange
            Mock<IStockHistory> mock = new Mock<IStockHistory>();
            mock.Setup(m => m.StockRecords).Returns(new StockRecord[] {
                new StockRecord { 
                    Symbol = "ABCDEFG", 
                    RecordDate = new DateTime(2000, 1, 1)
                }
            }.AsQueryable());
            CommonController target = new CommonController(mock.Object);
            // act
            JsonResult result = (JsonResult)target.GetStockHistory(new string[] { "ABCDEFG" });
            IEnumerable<IEnumerable<StockRecord>> allStocks = (IEnumerable<IEnumerable<StockRecord>>)result.Data;
            // assert
            Assert.AreEqual(1, allStocks.Count());
            StockRecord[] record1 = allStocks.ElementAt(0).ToArray();
            StockRecord record1_row1 = record1[0];
            
            Assert.AreEqual("ABCDEFG", record1_row1.Symbol);
        }
