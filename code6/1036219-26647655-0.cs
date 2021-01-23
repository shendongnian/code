    public ActionResult Login(string returnUrl)
    {           
         if (!String.IsNullOrEmpty(returnUrl))
            ViewBag.Message = "Please login to continue";
    }
