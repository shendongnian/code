    public class GlobalLibrary
    {
        private IWebDriver driver = null;
        //Constructor with optional parameter allows you to pass in driver of choice
        // OR pass in nothing and get the default Firefox driver 
        public GlobalLibrary(IWebDriver initDriver = null)
        {
            this.driver = initDriver ?? new FirefoxDriver();
        }
        public IWebDriver CurrentDriver  //Replaces Start Driver
        {
            get
            {
                return driver;
            }
        }
        //Rest of methods
    }
