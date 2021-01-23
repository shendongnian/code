        [Authorize(Roles = "Admin"] // <-- Make sure only admins can access this 
        public async Task<IActionResult> ImpersonateUser(String userId)
        {
            var currentUserId = User.GetUserId();
            var impersonatedUser = await _userManager.FindByIdAsync(userId);
            var userPrincipal = await _signInManager.CreateUserPrincipalAsync(impersonatedUser);
            userPrincipal.Identities.First().AddClaim(new Claim("OriginalUserId", currentUserId));
            userPrincipal.Identities.First().AddClaim(new Claim("IsImpersonating", "true"));
            // sign out the current user
            await _signInManager.SignOutAsync();
            
            // If you use asp.net core 1.0
            await HttpContext.Authentication.SignInAsync(cookieOptions.ApplicationCookieAuthenticationScheme, userPrincipal);
            // If you use asp.net core 2.0 (the line above is deprecated)
            await HttpContext.SignInAsync(cookieOptions.ApplicationCookieAuthenticationScheme, userPrincipal);
            return RedirectToAction("Index", "Home");
        }
