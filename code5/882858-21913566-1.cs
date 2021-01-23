    [HttpPost]
    public ActionResult LogOff()
    {
       var prevUrl = Request.UrlReferrer.AbsoluteUri;
       //Do the things to end the session       
       return RedirectToAction("Login", new { returnUrl=prevUrl});
    }
    public ActionResult Login(string returnUrl="")
    {
      var loginVM=new LoginVM();
      if(!String.IsNullOrEmpty(returnUrl))
         loginVM.ReturnUrl=returnUrl;
      return View(loginVM);
    }
