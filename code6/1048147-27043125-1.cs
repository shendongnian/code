    public class TestService : ITestService 
    {
    	public bool StartTest(int testId)
        {
            //Logic and rules for starting a test here
        }
    
        public bool FinishTest(int testId)
        {
            //Save the results in the DB            
        }
    } 
