    [Route("Register")]
    public async Task<IHttpActionResult> Register(RegisterBindingModel model)
    {
        //Do the register of the user
        //Next:
        await UserManager.AddToRoleAsync(userId, AccountRole.Admin);
    }
