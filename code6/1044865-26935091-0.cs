    public class MyController : Controller {
        private IConfigReader _configReader;
        public MyController(IConfigReader configReader){ //not sure if you're doing dependency injection or not, so I'm injecting it
             _configReader = configReader;
        }
        public ActionResult Index() {
            if(!_configReader.IsEnabled) {
                return RedirectToAction("Denied", "AuthController");
            }
    
            //etc
    
            return View();
        }
    }
