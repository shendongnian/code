    public Task SetProfile(UserProfile profile)
    {
        var cookie = new HttpCookie(AnonymousCookieName);
        cookie["name"] = profile.FullName;
        HttpContext.Current.Response.Cookies.Add(cookie);
        return Task.FromResult(null);
    }
