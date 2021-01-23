    public class MyMvcController : ServiceStackController
    {
        public ActionResult Index()
        {
            MyUserSession myServiceStackSession = base.SessionAs<MyUserSession>();
            
            return View();
        }
    }
