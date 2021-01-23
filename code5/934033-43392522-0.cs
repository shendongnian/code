        [HttpGet]
        public ActionResult LogOff(string token) { 
             AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
             return RedirectToAction("Index", "Home");
        }
        // Already Exists
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff() { 
             AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
             return RedirectToAction("Index", "Home");
        }
