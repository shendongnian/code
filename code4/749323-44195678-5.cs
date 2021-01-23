    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    const string sec = "ProEMLh5e_qnzdNUQrqdHPgp";
    const string sec1 = "ProEMLh5e_qnzdNU";
    var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(sec));
    var securityKey1 = new SymmetricSecurityKey(Encoding.Default.GetBytes(sec1)); 
    
    var signingCredentials = new SigningCredentials(
    	securityKey,
    	SecurityAlgorithms.HmacSha512);
    
    List<Claim> claims = new List<Claim>()
    {
    	new Claim("sub", "test"),
    };
    
    var ep = new EncryptingCredentials(
        securityKey1,
        SecurityAlgorithms.Aes128KW,
        SecurityAlgorithms.Aes128CbcHmacSha256);
    var handler = new JwtSecurityTokenHandler();
    
    var jwtSecurityToken = handler.CreateJwtSecurityToken(
        "issuer",
        "Audience",
        new ClaimsIdentity(claims),
        DateTime.Now,
        DateTime.Now.AddHours(1),
        DateTime.Now,
        signingCredentials,
        ep);
    
    
    string tokenString = handler.WriteToken(jwtSecurityToken);
    
    // Id someone tries to view the JWT without validating/decrypting the token,
    // then no claims are retrieved and the token is safe guarded.
    var jwt = new JwtSecurityToken(tokenString);
