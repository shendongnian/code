     HttpCookieCollection MyCookieCollection = Request.Cookies;
     HttpCookie MyCookie = MyCookieCollection.Get(name);
     if ( MyCookie != null)
     {
         HttpContext.Current.Request.Cookies.Remove(name);
     }
