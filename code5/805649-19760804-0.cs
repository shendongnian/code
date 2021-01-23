    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        [TestMethod]
        [DeploymentItem("PersonTestData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "|DataDirectory|\\PersonTestData.xml",
                   "Person",
                    DataAccessMethod.Sequential)]
        public void CompareToTest()
        {
            var row = TestContext.DataRow;
            var firstName = row["FirstName"].ToString();
            var lastName = row["LastName"].ToString();
           
            //Asserts...                 
        }
    }
