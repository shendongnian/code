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
            await HttpContext.Authentication.SignInAsync(cookieOptions.ApplicationCookieAuthenticationScheme, userPrincipal);
            return RedirectToAction("Index", "Home");
        }
