    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        Provider = new CookieAuthenticationProvider
        {
            OnResponseSignIn = signInContext =>
            {
                var expireTimeSpan = TimeSpan.FromMinutes(15);
                if (signInContext.Properties.Dictionary["organization"] == "org-1")
                {
                    expireTimeSpan = TimeSpan.FromMinutes(45);
                }
                signInContext.Properties.ExpiresUtc = DateTime.UtcNow.Add(expireTimeSpan);
            }
        }
    });
