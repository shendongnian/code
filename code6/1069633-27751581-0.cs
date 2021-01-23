    public class HomeController : Controller
    {
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set {_userManager = value; }
        }
    
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            ApplicationUser user = context.Users.FirstOrDefault(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase));
            if (user != null) UserManager.AddToRole(user.Id, RoleName);
            //Other code...
            return View("ManageUserRoles");
        }
    }
