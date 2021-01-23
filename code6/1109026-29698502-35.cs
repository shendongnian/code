        class JwtSignInHandler
        {
            public const string TokenAudience = "Myself";
            public const string TokenIssuer = "MyProject";
            private readonly SymmetricSecurityKey key;
            public JwtSignInHandler(SymmetricSecurityKey symmetricKey)
            {
                this.key = symmetricKey;
            }
            public string BuildJwt(ClaimsPrincipal principal)
            {
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: TokenIssuer,
                    audience: TokenAudience,
                    claims: principal.Claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: creds
                );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    Then, in your controller where you want your token, something like the following:
        [HttpPost]
        public string AnonymousSignIn([FromServices] JwtSignInHandler tokenFactory)
        {
            var principal = new System.Security.Claims.ClaimsPrincipal(new[]
            {
                new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, "Demo User")
                })
            });
            return tokenFactory.BuildJwt(principal);
        }
    Here, I'm assuming you already have a principal. If you are using Identity, you can use [`IUserClaimsPrincipalFactory<>`][0] to transform your `User` into a `ClaimsPrincipal`.
