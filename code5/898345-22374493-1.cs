    // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsUserExist(model.EMP_ID, model.EMP_PASSWORD))
                {
                    FormsAuthentication.SetAuthCookie(model.EMP_ID, false);
                    //change here
                    return RedirectToAction("Actionname","controllername","params if any"); 
    
                }
                else
                {
                    ModelState.AddModelError("", "The User ID or Password provided is incorrect.");
                }
            }
    
            
            return View(model);
        }
