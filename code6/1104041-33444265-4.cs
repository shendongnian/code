            //
            // POST: /Account/LogOff
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult LogOff()
            {
                AuthenticationManager.SignOut();
                return RedirectToAction("SetSessionVariables", "Account");
            }
    
            [AllowAnonymous]
            public ActionResult SetSessionVariables()
            {
                Session["HasAgreement"] = Agreement.HasAgreement(userId);
                return RedirectToAction("Index", "Home");
            }
