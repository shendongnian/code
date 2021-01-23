    public bool Login(string username, string password)
    {
       if (Membership.ValidateUser(username, password))
       {
           //FormsAuthentication.SetAuthCookie(username, true);
           // what should I do here?
           HttpCookie v_Cookie = FormsAuthentication.GetAuthCookie (username,true)
           HttpContext.Current.Response.Cookies.Add(v_Cookie);
           return true;
       }
    
       return false;
    }
