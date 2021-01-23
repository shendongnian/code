      [HttpPost]
            public ActionResult Login(User model, string returnUrl)
            {
                // Lets first check if the Model is valid or not
    
                if (ModelState.IsValid)
                {
                    using (DbEntities entities = new DbEntities())
                    {
                        string username = model.UserID;
                        string password = model.Password;
    
                        var UserAuth = db.Users.Where(x => x.UserID == model.UserID && x.Password == model.Password).FirstOrDefault();
    
                        // Now if our password was enctypted or hashed we would have done the
                        // same operation on the user entered password here, But for now
                        // since the password is in plain text lets just authenticate directly
    
                        bool userValid = entities.Users.Any(user => user.UserID == username && user.Password == password);
                        var usr = entities.Users.FirstOrDefault(x => x.UserID == username && x.Password == password);
                        if (userValid)
                        {
                            //System.Web.HttpContext.Current.Session["_SessionCompany"] = usr.DefaultCompanyID;
    
                            FormsAuthentication.SetAuthCookie(username, false);
                            if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                                && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                            {
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                //return RedirectToAction("Index", "Dossier");
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "The user name or password provided is incorrect.");
                        }
                    }
                }
    
                // If we got this far, something failed, redisplay form
                return View(model);
            }
