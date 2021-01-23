       public async Task<IActionResult> ImpersonateUserAsync(string email)
        {            
            var impersonatedUser = await _userManager.FindByNameAsync(email); //Usually username is the email
            await _signInManager.SignOutAsync(); //signout admin
            await _signInManager.SignInAsync(impersonatedUser,false); //Impersonate User
            return RedirectToAction("Index","Home");
        }
