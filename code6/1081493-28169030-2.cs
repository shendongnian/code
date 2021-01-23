    var facebookOptions = new FacebookAuthenticationOptions() {
                AuthenticationType = "Facebook",
                Caption = "Sign in with Facebook",
                AppId = "******",
                AppSecret = "*******",
                SignInAsAuthenticationType = signInAsType,
                Provider = new FacebookAuthenticationProvider() {
                    OnAuthenticated = (context) => {
                        foreach (var x in context.User) {
                            context.Identity.AddClaim(new Claim(x.Key, x.Value.ToString()));
                        }
                        
                        ExternalIdentity identity = new ExternalIdentity() {
                            Claims = context.Identity.Claims,
                            Provider = "Facebook",
                            ProviderId = "Facebook"
                        };
                        SignInMessage signInMessage = new SignInMessage();
                        
                        UserService.Get().AuthenticateExternalAsync(identity, signInMessage);
                        return Task.FromResult(context);
                    }
                },
            }
