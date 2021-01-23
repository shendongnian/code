    public class TestFacade
    {
        private ITestClass testClass;
    
        public TestFacade(PersonChoice personChoice)
        {
    
            // Get Instance of primary object
            ITestClass combinedClass = Arbitrator.getInstance(personChoice);
    
            testClass = combinedClass;
    
        }
    
        // expose property
        public ITestClass ITester
        {
            get
            {
                return testClass;
            }
        }
    
    }
