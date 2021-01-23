     public async Task<ActionResult> Register(RegisterViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { UserName = model.Username, Email = model.Username, workshopId =model.workshopId};
                    var rolesList = _context.Roles.ToList();
                    string role = rolesList.FirstOrDefault(r => r.Id == model.SelectedRoleId).Name;
                    var result = await UserManager.CreateAsync(user, model.Password);
                    
                    // Add User to the selected role from the list in .cshtml
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        result =await UserManager.AddToRoleAsync(user.Id, role);
                        // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                        // Send an email with this link
                        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
    
                        return RedirectToAction("Index", "Home");
                    }
                    AddErrors(result);
                }
    
                // If we got this far, something failed, redisplay form
                return View(model);
            }
