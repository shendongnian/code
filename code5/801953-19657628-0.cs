    [TestFixture]
    public class NUnitTests
    {
        [Test]
        public void fahrenheitToCelsiusBoilingTest()
        {
                float fahrenheit = 212F;
                float expected = 100F; // TODO: Initialize to an appropriate value
                float actual;
                actual = Form1.FahrenheitToCelsius(fahrenheit);
                Assert.AreEqual(Math.Round(expected, 2), Math.Round(actual, 2));
                //Assert.Inconclusive("Verify the correctness of this test method.");
        }
     }
