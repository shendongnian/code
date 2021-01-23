    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie objCookie = new HttpCookie(cnstLoginCookieName);
        objCookie.Values["Login"] = username.Trim();
        objCookie.Values["Company"] = "CoolFirm";
        objCookie.Expires = DateTime.MaxValue;
        Response.Cookies.Add(objCookie);
    }
