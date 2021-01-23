            if (provider == Provider.Yahoo)
            {
                DotNetOpenAuth.AspNet.AuthenticationResult result;
                var YahooClient = new YahooClient(clientId: clients[provider].AppID, clientSecret: clients[provider].AppSecret);
                var context = HttpContext.Current;
                //the second time
                if (!String.IsNullOrEmpty(context.Request.QueryString.ToString()) && (context.Request.QueryString.ToString().Contains("code")))
                {
                    result = YahooClient.VerifyAuthentication(new HttpContextWrapper(context), new Uri(returnUrl));
                    if (result.IsSuccessful)
                    {
                        state.Status = OAuth2Status.Success;
                    }
                }
                //the first time
                else
                {
                    OAuthWebSecurity.RegisterClient(YahooClient, "yahoo");
                    OAuthWebSecurity.RequestAuthentication("yahoo");
                    result = OAuthWebSecurity.VerifyAuthentication();
                    state.Status = OAuth2Status.Unauthorized;
                }
            }
