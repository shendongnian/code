    public class GlobalLibrary
    {
        private IWebDriver driver = null;
        //Constructor with optional parameter allows you to pass in driver of choice
        // OR pass in nothing and get the default Firefox driver 
        public GlobalLibrary(IWebDriver initDriver = null)
        {
            this.driver = initDriver ?? new FirefoxDriver();
        }
        //StartDriver is no longer necessary, but we might want to be able to
        // grab the driver that is being used, so we'll add this read-only property.
        public IWebDriver CurrentDriver  
        {
            get
            {
                return driver;
            }
        }
        //Rest of methods
    }
