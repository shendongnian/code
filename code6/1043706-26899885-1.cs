    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login([Bind(Include="username")] LoginModel myModel)
    { 
        var username = myModel.username;
    
        // do something with username
    
        return View("Congrats");
    }
