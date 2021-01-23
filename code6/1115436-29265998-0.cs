    String cookieName = "Foo"
    System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9 -]");
    String FullCookieName = ".OmniPro" + cookieName;
    HttpCookie oldCookie = Request.Cookies[FullCookieName];
    if (oldCookie != null)
    {
        String DeleteCookieName = rgx.Replace(FullCookieName, "");
        HttpCookie expiredCookie = new HttpCookie(DeleteCookieName) { Expires = DateTime.Now.AddDays(-1) };
        HttpContext.Current.Response.Cookies.Add(expiredCookie); // overwrite it
    }
