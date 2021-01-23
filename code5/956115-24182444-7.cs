        [Authorize(Roles = "Admin"] // <-- Make sure only admins can access this 
        public async Task<IActionResult> StopImpersonation()
        {
            if (!User.IsImpersonating())
            {
                throw new Exception("You are not impersonating now. Can't stop impersonation");
            }
            var originalUserId = User.FindFirst("OriginalUserId").Value;
            var originalUser = await _userManager.FindByIdAsync(originalUserId);
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(originalUser, isPersistent: true);
            return RedirectToAction("Index", "Home");
        }
