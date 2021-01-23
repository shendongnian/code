     // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl, string urlHash)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Sid, "Office365"));
            // Sign in the user with this external login provider if the user already has a login
            var user = await UserManager.FindAsync(loginInfo.Login);
            if (user == null)
            {
                user = await UserManager.FindByNameAsync(loginInfo.DefaultUserName);
                if (user != null)
                {
                    if(user.AllowExternalLogin == false)
                    {
                        ModelState.AddModelError("", String.Format("User {0} not allowed to authenticate with Office 365.", loginInfo.DefaultUserName));
                        return View("Login");
                    }
                    var result = await UserManager.AddLoginAsync(user.Id, loginInfo.Login);
                    if (result.Succeeded)
                    {
                        if (claims != null)
                        {
                            var userIdentity = await user.GenerateUserIdentityAsync(UserManager);
                            userIdentity.AddClaims(claims);
                        }
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    }
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", String.Format("User {0} not found.", loginInfo.DefaultUserName));
                    return View("Login");
                }
            }
            else
            {
                if (user.AllowExternalLogin == false)
                {
                    ModelState.AddModelError("", String.Format("User {0} not allowed to authenticate with Office 365.", loginInfo.DefaultUserName));
                    return View("Login");
                }
                
                if (claims != null)
                {
                    var userIdentity = await user.GenerateUserIdentityAsync(UserManager);
                    userIdentity.AddClaims(claims);
                }
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                return RedirectToLocal(returnUrl);
            }
        }
