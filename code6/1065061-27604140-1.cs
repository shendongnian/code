    [TestClass]
    public class SeleniumFeature : SeleniumBaseTest 
    {
        private DataSteps dataSteps;
        [TestInitialize]
        public void SeleInitialize()
        {
            dataSteps = new DataSteps();
        }
        [TestMethod]
        public void SomeTestMethod()
        {
            dataSteps.GivenSomethingExistsInTheDatabase();
        }
    }
