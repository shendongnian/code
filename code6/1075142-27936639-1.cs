    public Task SetProfile(UserProfile profile)
    {
        return Task.Run(() =>
        {
            var cookie = new HttpCookie(AnonymousCookieName);
            cookie["name"] = profile.FullName;
            HttpContext.Current.Response.Cookies.Add(cookie);
        });
    }
