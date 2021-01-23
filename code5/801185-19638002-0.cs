    public void AddCookie() {
        HttpCookie MyCookie = new HttpCookie("MyCookie");
        var userName = Session["LoginPersonID"].ToString();
        var originalCookieContents = ViewData["CookieData"].ToString();
        var ids = new HashSet<String>(originalCookieContents.Split(','));
        ids.Add(userName);
        MyCookie.Value = String.Join(",", ids);
        MyCookie.Expires = DateTime.Now.AddDays(30);
        Response.Cookies.Add(MyCookie);
        ViewData["CookieData"] = MyCookie.Value;
    }
