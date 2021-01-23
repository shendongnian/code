                public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }
                string userEmail = string.Empty;
                string userFacebookAccessToken = string.Empty;
                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
                Claim facebookToken = identity.Claims.First(x => x.Type.Contains("access_token"));
                Claim emailDetails = identity.FindFirst(ClaimTypes.Email);
                if (facebookToken != null) userFacebookAccessToken = facebookToken.Value;
                if (emailDetails != null)  userEmail = emailDetails.Value;
                //string userEmail = identity.Claims.First(x => x.Type.Contains("emailaddress")).Value;
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
                    Email = userEmail,
                    FacebookAccessToken = userFacebookAccessToken
                };
            }
        }
