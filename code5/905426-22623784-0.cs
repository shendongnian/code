    [HttpPost]
    public LoginResult PostSignIn([FromBody] Credentials credentials)
    {
        var auth = new LoginResult() { Authenticated = false };
        if (TryLogon(credentials.UserName, credentials.Password))
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, credentials.UserName), 
                    new Claim(ClaimTypes.Role, "Admin")
                }),
                AppliesToAddress = ConfigurationManager.AppSettings["JwtAllowedAudience"],
                TokenIssuerName = ConfigurationManager.AppSettings["JwtValidIssuer"],
                SigningCredentials = new SigningCredentials(new 
                    InMemorySymmetricSecurityKey(JwtTokenValidationHandler.SymmetricKey),
                    "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",
                    "http://www.w3.org/2001/04/xmlenc#sha256")
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                auth.Token = tokenString;
                auth.Authenticated = true;
            }
        return auth;
    }
