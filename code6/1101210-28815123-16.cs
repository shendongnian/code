    public class AccountServiceController
    {
        ISiteConfiguration Config {get; set;}
    
        //This is called constructor injection
        public AccountServiceController(ISiteConfiguration config)
        {
            Config = config;
        }
    
        public ActionResult Index()
        {
            //Now you can use Config without needing to know about ISiteConfiguration's implementation details
            //Get settings from Config instead of Application
        } 
    }
