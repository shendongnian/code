    if (Request.Cookies["latestVisit"] == null)
    {
        HttpCookie myCookie = new HttpCookie("latestVisit");
        myCookie.Expires = DateTime.Now.AddYears(1);
        myCookie.Values[title] = System.Web.HttpUtility.UrlEncode(URL);
        Response.Cookies.Add(myCookie);
    }
    else
    {
        var myCookie = Request.Cookies["latestVisit"];
        var cookieCollection = myCookie.Values;
        string[] CookieTitles = cookieCollection.AllKeys;
        //mj-y: If the url is reapeated, move it to end(means make it newer by removing it and adding it again)
        string cookieURL = "";
        foreach (string cookTit in CookieTitles)
        {
            cookieURL = System.Web.HttpUtility.UrlDecode(Request.Cookies["latestVisit"].Values[cookTit]);
            if (cookieURL == URL)
            {
                cookieCollection.Remove(cookTit);
                cookieCollection.Set(title, System.Web.HttpUtility.UrlEncode(URL));
                Response.SetCookie(myCookie);
                return;
            }
        }
        //mj-y: If it was not repeated ...
        cookieCollection.Set(title, System.Web.HttpUtility.UrlEncode(URL));
        if (cookieCollection.Count > 15) // store just 15 item         
            cookieCollection.Remove(CookieTitles[0]);
        Response.SetCookie(myCookie);
    }
