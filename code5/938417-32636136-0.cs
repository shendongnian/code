        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            // (...) ModelState.IsValid, etc
            
            string user_name = ""; // in case 'user' is null (user not found)
            var user = await UserManager.FindByEmailAsync(model.Email);
            
            if (user != null)
            {
                user_name = user.UserName;
                if (!await UserManager.IsEmailConfirmedAsync(user.Id))
                {
                    // (...) Require the user to have a confirmed email before they can log on, etc
                }
            }
            // don't use model.Email below, use the value from user.UserName (if user not null)
            var result = await SignInManager.PasswordSignInAsync(user_name, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                // (...)
