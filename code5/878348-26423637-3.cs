         //GET
        [AllowAnonymous]
        public ActionResult RegisterNewUser()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterNewUser(RegisterNewUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = userViewModel.Email,
                    Email = userViewModel.Email,
                    EmailConfirmed =true
                };
                var adminresult = await UserManager.CreateAsync(user, userViewModel.Password);
                //Add User to the Roles 
                   string[] selectedRoles=new string[]{"Developer","Tester","Robbot"};
                if (adminresult.Succeeded)
                {
                    if (selectedRoles != null)
                    {
                        var result = await UserManager.AddToRolesAsync(user.Id, selectedRoles);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", result.Errors.First());
                            return View();
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", adminresult.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }
