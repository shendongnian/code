    this.Provider = new Microsoft.Owin.Security.Google.GoogleOAuth2AuthenticationProvider
            {
                OnApplyRedirect = async context =>
                    {
                        string redirect = context.RedirectUri;
                        if (context.Request.Uri.ToString().Contains("login_hint"))
                        {
                            // Change the value of "redirect" here
                            // e.g. append access_type=offline
                        }
                        context.Response.Redirect(redirect);
                    },
                OnAuthenticated = async context =>
                {
                    // Do stuff
                }
            };
