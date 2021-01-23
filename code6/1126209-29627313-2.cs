    public class HomeController : Controller
    {
        private IUserBm userBm;
        public HomeController(IUserBm userBm)
        {
          this.userBm = userBm;
        }
        ...
