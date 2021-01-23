        [TestMethod]
        public void Test()
        {
            // Arrange.
            using (var context = new Context())
            {
                var models = new List<CarModel> { 
                    new CarModel { Name = "A car model" }, 
                    new CarModel { Name = "Another car model" }
                };
                var brand = new Brand { Name = "A Brand", Models = models };
                var brandRepository = new BrandRepository(context);
                brandRepository.Add(brand);
                brandRepository.Save();
            }
            // Act.
            using (var context = new Context())
            {
                var brandRepository = new BrandRepository(context);
                var brand = brandRepository.FindByName("A brand");
                brandRepository.RemoveCarModel(brand, "A car model");
                brandRepository.Save();
            }
            // Assert.
            using (var context = new Context())
            {
                var brandRepository = new BrandRepository(context);
                var brand = brandRepository.FindByName("A brand");
                Assert.AreEqual(1, brand.Models.Count);
                Assert.AreEqual("Another car model", brand.Models.Single().Name);
            }
        }
