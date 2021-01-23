    public class LoginController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthenticateUserByCard(string token)
        {
            //Authenticate user and redirect to a specific view based on the user role
            Role role = GetRoleByToken(token);
            if(role.UserType == UserType.Supervisor)
                return Supervisor(token);
            else
                return Cashier(token);
            return null;
        }
        public ActionResult Supervisor(string id)
        {
            //Do some processing and display the Supervisor View
            return View("Supervisor");
        }
        public ActionResult Cashier(string id)
        {
            //Do some processing and display the Cashier View
            return View("Cashier");
        }
