    [HttpPost]
        public ActionResult Login(string username, string password) 
        {
            if (username == password) 
            {
                FormsAuthentication.SetAuthCookie(username, true);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpUnauthorizedResult();
        }
