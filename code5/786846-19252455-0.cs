    if (Request.Cookies[key] != null)
    {
        HttpCookie myCookie = new HttpCookie(key);
        myCookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(myCookie);
    }
