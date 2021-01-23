    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(string username)
    { 
    	LoginModel myModel = new LoginModel();
    	myModel.username = username;
    
        // do something with username
    
        return View("Congrats");
    }
