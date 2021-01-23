    public class HomeController : Controller
        {
            private readonly IHomeHub _hub;
    
            public HomeController(IHomeHub hub)
            {
                _hub = hub;
            }
    
            public ActionResult Index()
            {
                _hub.Hello();
                return View();
            }
    }
     public interface IHomeHub
        {
            void Hello();
        }
        public class HomeHub : Hub, IHomeHub
        {
            public void Hello()
            {
                Clients.All.hello();
            }
        }
