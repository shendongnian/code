    string mySessionCookie = System.Web.HttpContext.Current.Request.Headers["Cookie"];
    if (mySessionCookie.IndexOf(".ASPXAUTH", StringComparison.Ordinal) >= 0) {
        // do something
    }
    
