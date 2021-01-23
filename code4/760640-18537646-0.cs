    Read cookie:
    
    HttpCookie aCookie = Request.Cookies["UserSettings"];
    if(aCookie != null) {
         object userSettings = aCookie.Value;
    } else {
         //Cookie not set.
    }
    
    To set a cookie:
    
    HttpCookie cookie = new HttpCookie("UserSettings");
    
    cookie["UserSettings"] = myUserSettingsObject;
    cookie.Expires = DateTime.Now.AddYears(1);
    Response.Cookies.Add(cookie);
