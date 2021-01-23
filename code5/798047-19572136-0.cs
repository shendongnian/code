            OAuthBearerOptions = new OAuthBearerAuthenticationOptions()
            {
                Provider = new OAuthBearerAuthenticationProvider
                {
                    OnValidateIdentity = async ctx =>
                        {
                            ctx.Rejected();
                        }
                }
            };
