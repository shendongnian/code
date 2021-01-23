     [HttpPost]
    public ActionResult Login(Models.user_master model, string returnUrl = "")
    {
      
            if (ValidateUser(model.UserID,model.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(model.UserID,false);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ModelState.AddModelError("", "Login details are wrong.");
            }
            return View(model);
       
    }
