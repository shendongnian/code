    [Route("CreateIdentity")]
    public async Task<IHttpActionResult> CreateIdentity([FromBody] string authenticationType)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            ClaimsIdentity userIdentity = await user.GenerateUserIdentityAsync(UserManager, authenticationType);
            return Ok(userIdentity);
        }
