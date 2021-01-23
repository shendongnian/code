     public async Task<IHttpActionResult> Login([FromBody]string email)
        {
            var user = await UserManager.FindByNameAsync(email);
            Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
            return Ok();
        }
