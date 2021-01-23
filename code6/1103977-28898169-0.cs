    string username="";
    var cookie = Request.Headers.GetCookies("MyCookie").SingleOrDefault();
    
    if (cookie != null)
    {
        username = cookie["MyCookie"].Value;
    }
