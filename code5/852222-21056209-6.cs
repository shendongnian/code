    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test()
        {
            // Arrange.
            var context = new Context();
            var brandRepository = new BrandRepository(context);
            var models = new List<CarModel> { 
                new CarModel { Name = "A car model" }, 
                new CarModel { Name = "Another car model" }
            };
            var brand = new Brand { Name = "A Brand", Models = models };
            brandRepository.Add(brand);
            brandRepository.Save(); // Not needed, but there if you want to inspect the database while debugging.
            // Act.
            var carModelToRemove = brand.Models.Single(cm => cm.Name == "A car model");
            brand.Models.Remove(carModelToRemove); // Should be refactored to BrandRepository.RemoveCarModel(brand, "A car model").
            brandRepository.Save();
            // Assert.
            var brandAfterRemoval = context.Brands.Single(b => b.Name == "A brand");
            Assert.AreEqual(1, brandAfterRemoval.Models.Count);
            Assert.AreEqual("Another car model", brandAfterRemoval.Models.Single().Name);
        }
    }
