    public ActionResult Index()
    {
        getCredentials();
        if (Authenticate(userName, password))
        {
            return View();
        }
    
        ModelState.AddModelError("", "Could not authenticate");
        return View();
    }
