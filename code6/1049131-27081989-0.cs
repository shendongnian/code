    // to send a cookie
    var myCookie = Response.Cookies.Get("UserSettings");
    myCookie.Values.Add("userGUID", System.Guid.NewGuid().ToString("N"));
    myCookie.Expires = DateTime.Now.AddDays(2);
    // to retrieve 
    var myCookie = Response.Cookies.Get("UserSettings");
    var userGUID = myCookie.Values["userGUID"];
