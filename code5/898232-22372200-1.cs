    /// <summary> /// Logs user out and renders login <see cref="View"/> /// </summary> /// <returns>Login <see cref="View"/></returns>
        public ActionResult Logout()
        {
                //Disable back button In all browsers.
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                Response.Cache.SetNoStore();
    
                FormsAuthentication.SignOut();
                return View("Login");
         }
