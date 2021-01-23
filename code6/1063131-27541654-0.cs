        [HttpGet]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            Session.Clear();
    
            return RedirectToAction("Index", "Home");
        }
    
        [HttpPost]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            Session.Clear();
    
            return RedirectToAction("Index", "Home");
        }
