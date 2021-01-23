        public ActionResult StupidCompanyLogin()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken] - Whats the point? F**k security 
        public async Task<ActionResult> StupidCompanyLogin(string name)
        {
            var user = await UserManager.FindByNameAsync(name);
            if (user != null)
            {
                await SignInManager.SignInAsync(user, true, true);
            }
            return View();
        }
