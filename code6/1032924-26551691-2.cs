    // GET api/Account/ExternalLogin
    [OverrideAuthentication]
    [HostAuthentication(Startup.ExternalCookieAuthenticationType)]
    [AllowAnonymous]
    [HttpGet("ExternalLogin", RouteName = "ExternalLogin")]
    public async Task<IHttpActionResult> ExternalLogin(string provider)
    {
        // Auth code
    }
 
