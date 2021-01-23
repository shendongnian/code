        [AuthorizeUser]
        public class UserController : BaseController<Users>
        {
           [HttpPost]
           [ValidateAntiForgeryToken]
           public ActionResult LogOff()
           {
               FormsAuthentication.SignOut();
               return RedirectToAction("UserLogin");
           }
        }
