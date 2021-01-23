        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var Db = new ApplicationDbContext();
    
                var user = await UserManager.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                    await SignInAsync(user, model.RememberMe);
    
                    var temp = Db.Users.Find(user.UserName);
                    temp.LastLogin = DateTime.UtcNow;
                    Db.Entry(temp).State = EntityState.Modified;
                    await Db.SaveChangesAsync();
    
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
    
            // If we got this far, something failed, redisplay form
            return View(model);
        }
