        public void TestMethod()
        {
            //Arrange
            //...
            //Act
            //...
            //Assert
            AssertAnimals(expectedAnimals, actualAnimals);
        }
        private void AssertAnimals(IEnumerable<Animal> expectedAnimals, IEnumerable<Animal> actualAnimals)
        {
            ListAsserter.AssertListEquals(
                (e,a) => AssertAnimal(e,a),
                expectedAnimals,
                actualAnimals);
        }
        private void AssertAnimal(Animal expected, Animal actual)
        {
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Weight, actual.Weight);
            //Additional properties to assert...
        }
