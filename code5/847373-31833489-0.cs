            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> EnableTwoFactorAuthentication()
            {
                await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), true);
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", "Manage");
            }
