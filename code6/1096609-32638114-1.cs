            private class ExternalLoginData
            {
                public string LoginProvider { get; set; }
                public string ProviderKey { get; set; }
                public string UserName { get; set; }
                public string Token { get; set; }
    
                public IList<Claim> GetClaims()
                {
                    IList<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));
    
                    if (UserName != null)
                    {
                        claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
                    }
    
                    if (Token != null)
                    {
                        claims.Add(new Claim("FacebookAccessToken", Token, null, LoginProvider));
                    }
    
                    return claims;
                }
    
                public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
                {
                    if (identity == null)
                    {
                        return null;
                    }
    
                    Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
    
                    if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
                        || String.IsNullOrEmpty(providerKeyClaim.Value))
                    {
                        return null;
                    }
    
                    if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                    {
                        return null;
                    }
    
                    return new ExternalLoginData
                    {
                        LoginProvider = providerKeyClaim.Issuer,
                        ProviderKey = providerKeyClaim.Value,
                        UserName = identity.FindFirstValue(ClaimTypes.Name),
                        Token = identity.Claims.FirstOrDefault(x => x.Type.Contains("FacebookAccessToken")).Value
                    };
                }
            }
