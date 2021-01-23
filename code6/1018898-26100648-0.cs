        [SetUp]
        public void SetupUnitTestPrinciple()
        {
           var identity = new GenericIdentity("Unitest");
           System.Threading.Thread.CurrentPrincipal = new CustomPrincipal(identity);
        }
