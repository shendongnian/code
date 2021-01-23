    public class UserController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        [HttpGet]
        public ActionResult ListUser()
        {
            var users = db.Users.ToList();
            var viewModel = new ListUserViewModel { Users = users };
            return View(viewModel);
        }
    }
