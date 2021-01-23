        //you have to call this function at every request a user makes
        internal static void saveUserSessionID(string email)//email or any unique string to user
        {
            var dir = HostingEnvironment.MapPath("~/temp/UserSession/");// a folder you choose
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string path = dir + email + ".txt";
            File.WriteAllText(path, HttpContext.Current.Session.SessionID);
        }
        
        // if a request has not been made in tha last 4 minutes, the user left, closed the browser
        // the test checks this only on a real server, localhost is not tested to be easy for the developer
        internal static bool alreadyLoggedIn(string email)
        {
            var file = HostingEnvironment.MapPath("~/temp/UserSession/" + email + ".txt");
            return File.Exists(file) && File.GetLastWriteTime(file).AddMinutes(4) > DateTime.Now && !HttpContext.Current.Request.IsLocal;
        }
