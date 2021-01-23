    public ActionResult Index()
         {
             //Code to create ResetPassword URL
    	     var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
             var user = userManager.FindByName("useremail@gmail.com");
             string code = userManager.GeneratePasswordResetToken(user.Id);
             var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
             return View();
         }
