    //clear authentication cookie
    HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
    cookie1.Expires = DateTime.Now.AddYears(-1);
    cookie1.Domain = "mysite.org";
    Response.Cookies.Add(cookie1);
    
    //clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
    HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
    cookie2.Expires = DateTime.Now.AddYears(-1);
    cookie2.Domain = "mysite.org";
    Response.Cookies.Add(cookie2);
