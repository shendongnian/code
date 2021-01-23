    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    const string sec = "ProEMLh5e_qnzdNUQrqdHPgp";
    const string sec1 = "ProEMLh5e_qnzdNU";
    var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(sec));
    var securityKey1 = new SymmetricSecurityKey(Encoding.Default.GetBytes(sec1));
    
    // This is the input JWT which we want to validate.
    string tokenString = string.Empty;
    
    // If we retrieve the token without decrypting the claims, we won't get any claims
    // DO not use this jwt variable
    var jwt = new JwtSecurityToken(tokenString);
    
    // Verification
    var tokenValidationParameters = new TokenValidationParameters()
    {
    	ValidAudiences = new string[]
    	{
    		"536481524875-glk7nibpj1q9c4184d4n3gittrt8q3mn.apps.googleusercontent.com"
    	},
    	ValidIssuers = new string[]
    	{
    		"https://accounts.google.com"
    	},
    	IssuerSigningKey = securityKey,
    	// This is the decryption key
    	TokenDecryptionKey = securityKey1
    };
        
    SecurityToken validatedToken;
    var handler = new JwtSecurityTokenHandler();
    
    handler.ValidateToken(tokenString, tokenValidationParameters, out validatedToken);
