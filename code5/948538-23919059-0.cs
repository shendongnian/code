    HttpCookie AuthCookie = new HttpCookie("MyCookie");
    AuthCookie.Values["eventcode"] = EventCode;
    AuthCookie.Values["id"] = sBuilder.ToString();
    AuthCookie.Expires = DateTime.Now.AddDays(1);
    Response.Cookies.Add(aCookie);
