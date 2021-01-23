                const string sec = "ProEMLh5e_qnzdNUQrqdHPgp";
                const string sec1 = "ProEMLh5e_qnzdNU";
                var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.Default.GetBytes(sec));
                var securityKey1 = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.Default.GetBytes(sec1)); 
    
                var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    securityKey,
                    Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha512);
    
                List<Claim> claims = new List<Claim>()
                {
                    new Claim("sub", "test"),
                };
    
                var ep = new Microsoft.IdentityModel.Tokens.EncryptingCredentials(securityKey1, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.Aes128KW, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.Aes128CbcHmacSha256);
                var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
    
                var jwtSecurityToken = handler.CreateJwtSecurityToken("issuer", "Audience", new ClaimsIdentity(claims), DateTime.Now, DateTime.Now.AddHours(1), DateTime.Now, signingCredentials, ep);
                
                string tokenString = handler.WriteToken(jwtSecurityToken);
               
                // Id someone tries to view the JWT without validating/decrypting the token, then no claims are retrieved and the token is safe guarded.
                var jwt = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(tokenString);
