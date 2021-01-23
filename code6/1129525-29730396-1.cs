    [TestFixture]
    public class CoffeeMakerTests
    {
        [Test]
        public void MakeDrink_CoffeeWithMilk_ReturnsCorrectString() // Testa metoden för kaffe med mjölk. Uppgift 2(b)
        {
            // Arrange
            var coffeemaker = new CoffeeMaker();
            var coffeeWithMilk = new Coffee(true, false));
            // Act
            var resultString = coffeemaker.MakeDrink(coffeeWithMilk);
            // Assert
            StringAssert.Contains("Coffee with milk", resultString);
        }
    }
