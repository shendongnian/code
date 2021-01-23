    private static void ValidateJwt(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();   
            var validationParameters = new TokenValidationParameters()
            {
                ValidAudience = "https://my-rp.com",
                IssuerSigningTokens = new List<X509SecurityToken>() { new X509SecurityToken(
                   X509
                   .LocalMachine
                   .My
                   .Thumbprint
                   .Find("UYTUYTVV99999999999YTYYTYTY88888888", false)
                   .First()) },
                ValidIssuer = "https://my-issuer.com/trust/issuer",
                CertificateValidator = X509CertificateValidator.None,
                RequireExpirationTime = true
            };
            try
            {
                SecurityToken validatedToken;
                var principal = handler.ValidateToken(jwt, validationParameters, out validatedToken);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}\n {1}", e.Message, e.StackTrace);
            }
            Console.WriteLine();
        }
