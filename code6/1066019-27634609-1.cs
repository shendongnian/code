    namespace Website.Controllers
    {
        public class HomeController : BaseController
        {
    
            static int counter = 0;
            static object lockObj = new object();
            public ActionResult DoSomething()
            {
                lock(lockObj)
                {
                    counter++;
                }
                // Do more
    
                return View();
            }
        }
    }
