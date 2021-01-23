    public static class User
    {
        public static bool IsAuthenticated
        {
            get
            {
                var session = HttpContext.Current.Session;
                return !string.IsNullOrEmpty(session["LoggedInUser"]);
            }
        }
        public static string UserName
        {
            get
            {
                return session["LoggedInUser"];
            }
        }
        public static bool Login(string userName, string password)
        {
            // login (i.e. verify the user name and password
            // build some kind of session indicator
            HttpContext.Current.Session["LoggedInUser"] = userName;
            return true;
        }
        public static void Logout()
        {
            if (!IsAuthenticated) { return; }
            HttpContext.Current.Session.Abandon();
        }
    }
