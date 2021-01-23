        public ActionResult Login()
        {
           if (User.Identity.IsAuthenticated)
           {
              return PartialView("_loggedInPartial");
           }
           else
           {
              return PartialView("_notLoggedInPartial");
           }
         }
