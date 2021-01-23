    Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = MySecurityStampValidator.OnValidateIdentity(
                        validateInterval: TimeSpan.FromMinutes(0),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
