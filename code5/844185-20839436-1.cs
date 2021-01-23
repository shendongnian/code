    private bool Login(string userName, string password,bool rememberMe)
    {
    if (Membership.ValidateUser(userName, password))
    {
        CookieHelper newCookieHelper = 
		new CookieHelper(HttpContext.Request,HttpContext.Response);
        newCookieHelper.SetLoginCookie(userName, password, rememberMe);
        return true;
    }
    else
    {
        return false;
    }
    } 
