    app.UseCookieAuthentication(new CookieAuthenticationOptions {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString("/Account/Login"),
            Provider = new CookieAuthenticationProvider {
                OnValidateIdentity = ctx => {
                    return validateFn.Invoke(ctx);
                },
                OnApplyRedirect = ctx =>
                {
                    bool enableRedir = true;
                    if (ctx.Response != null)
                    {
                        string respType = ctx.Response.ContentType;
                        string suppress = ctx.Response.Headers["Suppress-Redirect"];
                        if (respType != null)
                        {
                            Regex rx = new Regex("^application\\/json(;(.*))?$",
                                RegexOptions.IgnoreCase);
                            if (rx.IsMatch(respType))
                            {
                                enableRedir = false;
                            }  
                        }
                        if ((!String.IsNullOrEmpty(suppress)) && (Boolean.Parse(suppress)))
                        {
                            enableRedir = false;
                        }
                    }
                    if (enableRedir)
                    {
                        ctx.Response.Redirect(ctx.RedirectUri);
                    }
                }
            }
        });
