    public class LoginController: Controller
    {
        public ActionResult Index()
        {
            string windowsUserName = Request.ServerVariables["LOGON_USER"];
            if (!string.IsNullOrEmpty(windowsUserName))
            {
                Regex regex = new Regex(@"(^\w+)\\", RegexOptions.IgnoreCase);
                string userName = regex.Replace(windowsUserName, string.Empty);
                // validate the user name against ad here
                FormsAuthentication.SetAuthCookie(userName, false);
                this.RedirectToAction("Index", "Home");
            }
            else
            {
                // if the user isn't signed in with AD credentials you can send an
                // "unauthorized" http code and the browser (excluding Firefox)
                // will try to send credentials (if available).
                // you will have to manage staying out of a redirect loop
                // many options here: set and check a cookie, session, headers, etc.
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
        }
    }
