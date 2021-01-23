    [TestFixture]
    public class LandForSale
    {
        private IWebDriver driver = null;
        GlobalLibrary globalLib = null;
        [SetUp]
        public void OpenBrowser()
        {
            globalLib = new GlobalLibrary(driver);
            globalLib.StartDriver();           
        }
        [Test]
        public void TestScenario()
        {
            string[] setofitems = { "Residential", "Commercial" };
            foreach (string item in setofitems)
            {
               globalLib.OpenUrl(); //If the OpenBrowser() method is not called then globalLib is null
               globalLib.Search();
               etc...
            }
        }       
    }
