    namespace //not included
    {
        public class HomeController : Controller
        {
    
            public ActionResult Index()
            {
                return View();
            }
    
    
            public ActionResult AddDetails()
            {
               Customer newCustomer = new Customer();
                return View(newCustomer);
               //right click this action and choose addview and use strongly typed 
               //view by choosing Customer class
            }
    
    
            [HttpPost]
            public ActionResult AddDetails(Customer customer)
            {
                //whatever you want here
            }
    
    
        }
    }
