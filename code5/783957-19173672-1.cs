        [TestMethod]
        public void TestCreate() {
            // Setup
            AdvertisementController controller = new AdvertisementController();
            ViewResult result = controller.Create() as ViewResult;
            var expectedCategories = new SelectList(new[] { "Electronics", "Toys", "Books", "Sporting Goods" }).ToList();
            // Execute
            var actualCategories = result.ViewBag.categoryList.ToList();
            // Assert
            Assert.IsNotNull(result); 
            Assert.AreEqual(expectedCategories[0], actualCategories[0]);
            Assert.AreEqual(expectedCategories[1], actualCategories[2]);
            Assert.AreEqual(expectedCategories[2], actualCategories[3]);
            Assert.AreEqual(expectedCategories[3], actualCategories[4]);
            Assert.AreEqual(expectedCategories[4], actualCategories[5]);
        }
