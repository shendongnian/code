    // POST api/Account/RegisterExternalToken
    [OverrideAuthentication]
    [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
    [Route("RegisterExternalToken")]
    public async Task<IHttpActionResult> RegisterExternalToken()
    {
        ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);
        
        if (externalLogin == null)
        {
            return InternalServerError();
        }
        
        var facebookToken = externalLogin.Token;
