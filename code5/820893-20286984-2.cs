    OAuth2Parameters parameters = new OAuth2Parameters()
                        {
                            ClientId = CLIENT_ID,
                            ClientSecret = CLIENT_SECRET,
                            AccessCode = token,
                            RedirectUri = REDIRECT_URI //needed because of a bug
                        };
                        OAuthUtil.GetAccessToken(Request.Url.Query, parameters);                      
                        BaseClientService.Initializer init = new BaseClientService.Initializer { Authenticator = new AuthenticatorImp(parameters)};
                        PlusService service = new PlusService(init);
                        Person me = service.People.Get("me").Execute();
