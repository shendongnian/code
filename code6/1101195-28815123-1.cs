    public class ProductController
    {
        ISiteConfiguration Config {get; set;}
    
        //This is called constructor injection
        public ProductController(ISiteConfiguration config)
        {
            Config = config;
        }
    
        public ActionResult Index()
            {
                //Now you can use Config without needing to know about WebConfiguration class
            } 
    }
