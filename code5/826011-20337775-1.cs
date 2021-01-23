     [TestMethod]
        public void ProductTest()
        {
            // Arrange
            using (new TransactionScope())
            {
                myContext db = new myContext();
                var originalCount = db.Products.ToList().Count();
    
                Product testProduct = new Product
                {
                    ProductId = 999999,
                    CategoryId = 3,
                    ShopId = 2,
                    Price = 1.00M,
                    Name = "Test Product",
                    Visible = true
                };
    
                // Act
                db.Products.Add(testProduct);
                db.SaveChanges();
    
                // Assert
                Assert.AreEqual(originalCount + 1, db.Products.ToList().Count());
                // Fails since there are already items in database
    
            }
    
        }
