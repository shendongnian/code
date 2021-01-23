    [HttpPost, Route("Token")]
    public IHttpActionResult Token(LoginViewModel login)
    {
        ClaimsIdentity identity;
        if (!_loginProvider.ValidateCredentials(login.UserName, login.Password, out identity))
        {
            return BadRequest("Incorrect user or password");
        }
        var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
        var currentUtc = new SystemClock().UtcNow;
        ticket.Properties.IssuedUtc = currentUtc;
        ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));
        return Ok(new LoginAccessViewModel
        {
            UserName = login.UserName,
            AccessToken = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket)
        });
    }
