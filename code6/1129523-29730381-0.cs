    [TestFixture]
    public class CoffeeMakerUnitTests
    {
        [Test]
        public void Test_MakeCoffeeWithMilk_Succeeds()
        {
            // Arrange
            var coffemaker = new CoffeeMaker();
    
            // Act
            string res = coffemaker.MakeDrink(new Coffee(true, false));
    
            // Assert
            StringAssert.Contains("Coffee with milk", res);
        }
    }
