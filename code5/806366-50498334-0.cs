    private async Task<ExternalLoginInfo> AuthenticationManager_GetExternalLoginInfoAsync_WithExternalBearer()
            {
                ExternalLoginInfo loginInfo = null;
    
                var result = await Authentication.AuthenticateAsync(DefaultAuthenticationTypes.ExternalBearer);
    
                if (result != null && result.Identity != null)
                {
                    var idClaim = result.Identity.FindFirst(ClaimTypes.NameIdentifier);
                    if (idClaim != null)
                    {
                        loginInfo = new ExternalLoginInfo()
                        {
                            DefaultUserName = result.Identity.Name == null ? "" : result.Identity.Name.Replace(" ", ""),
                            Login = new UserLoginInfo(idClaim.Issuer, idClaim.Value)
                        };
                    }
                }
                return loginInfo;
            }
