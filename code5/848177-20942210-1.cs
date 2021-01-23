    public class EmployeeController : Controller
    {
        [MyRoleAuthorization("Employee")]
        public ActionResult Index()
        {
            return View();
        }
    }
