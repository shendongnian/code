	public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            T user = await _userManager.FindAsync(context.UserName, context.Password);
            if (user == null)
            {
                if (((int) HttpContext.Current.Session["Tries"]) >= 5)
                {
                    context.SetError("maximum_tries", "You tried too many times");
                    return;
                }
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                HttpContext.Current.Session["Tries"] = ((int)HttpContext.Current.Session["Tries"]) + 1;
                return;
            }
            ClaimsIdentity oAuthIdentity = await _userManager.CreateIdentityAsync(user,
                context.Options.AuthenticationType);
            var ticket = new AuthenticationTicket(oAuthIdentity, GenerareProperties(user));
            context.Validated(ticket);
            ClaimsIdentity cookiesIdentity = await _userManager.CreateIdentityAsync(user,
                CookieAuthenticationDefaults.AuthenticationType);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
            HttpContext.Current.Session["Tries"] = 0;
        }
