        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeLogin(string returnUrl)
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account", new System.Web.Routing.RouteValueDictionary { { "returnUrl", returnUrl } });
        }
