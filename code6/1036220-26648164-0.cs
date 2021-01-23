        public ActionResult EntryPoint()
        {
            TempData["CameFromEntryPoint"] = true;
            return Redirect("Login");
        }
        public ActionResult Login()
        {
            if(RequestIsARedirect())
                ViewBag.LoginMessage = "Please login to Continue";
            return View();
        }
        private bool RequestIsARedirect()
        {
            return TempData["CameFromEntryPoint"] != null && (bool) TempData["CameFromEntryPoint"];
        }
