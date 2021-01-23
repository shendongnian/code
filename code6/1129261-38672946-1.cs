     public async Task<ActionResult> SignIn()
        {
            var context = System.Web.HttpContext.Current;
            AuthUser authUser = new AuthUser(context);
            await authUser.SignIn("waleedchayeb2@gmail.com", "123456");
            return RedirectToAction("Index", "Home");
        }
