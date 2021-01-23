        [HttpGet]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            Session.Clear();
    
            return RedirectToAction("Index", "Home");
        }
    
        [HttpPost]
        public ActionResult LogOff(FormCollection c)
        {
            WebSecurity.Logout();
            Session.Clear();
    
            return RedirectToAction("Index", "Home");
        }
