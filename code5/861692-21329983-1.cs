        /// <summary>Logs off the user. POST: /Account/LogOff.</summary>
        /// <returns>The Action Result.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return this.RedirectToAction("login", "Account");
        }
