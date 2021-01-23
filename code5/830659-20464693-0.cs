        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var userInfo = new UserInfo
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    //AppType = "Web"
                };
                var service = new ATWMSService();
                if(service.ValidateUser(userInfo))
                {
                    Session["UserId"] = service.GetUserId(userInfo.UserName);
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    return Redirect("~/");
                }
                ModelState.AddModelError("","The user name or password provided is incorrect.");
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }   
