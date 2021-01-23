    [HttpPost]
    public async Task<HttpResponseMessage> Login([FromBody]LoginApiViewModel model)
    {
        if (!ModelState.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest, "Username or password is not supplied");
        var user = UserManager.Find(model.Username, model.Password);
        if (user != null && UserManager.IsInRole(user.Id, "Administrator"))
        {
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Success");
            return response;
        }
        return Request.CreateResponse(HttpStatusCode.Unauthorized, "Wrong login");
    }
