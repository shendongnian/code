    string username= Request.QueryString["Username"];
    string password = Request.QueryString["Password"];
    
    if (FormsAuthentication.Authenticate(username, password))
    {
    	FormsAuthentication.RedirectFromLoginPage(username, true);
    }
