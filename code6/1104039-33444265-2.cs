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
                if (!User.Identity.IsAuthenticated)
                {
                    \\ set null, abandon or whatever
                    Session["HasAgreement"] = Agreement.HasAgreement(userId);
                }
                else
                {
                    \\maybe slight pause and something here so it can't get caught in a continuous loop
                    return RedirectToAction("SetSessionVariables", "Account");
                }
                
                return RedirectToAction("Index", "Home");
            }
