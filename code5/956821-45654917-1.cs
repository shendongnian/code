    [Authorize(Roles = Roles.ADMIN]
    public class ExampleController : Controller
    {
        [Authorize(Roles = Roles.ADMIN_OR_VIEWER)
        public ActionResult Create()
        {
            ..code here...
        }
    }
