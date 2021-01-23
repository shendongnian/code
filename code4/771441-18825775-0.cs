    string[] myCookies = HttpContext.Current.Request.Cookies.AllKeys;
    foreach (string cookieName in myCookies)
    {
          var cookie = HttpContext.Current.Response.Cookies[cookieName];
          if (cookie != null)
          {
                cookie.Value = "";
                cookie.Expires = DateTime.Now.AddDays(-1);
          }
    }
