    public class BaseController : Controller
    {
        public ISessionWrapper SessionWrapper { get; set; }
        public BaseController()
        {
            SessionWrapper = new HttpContextSessionWrapper();
        }
    }
