    if (Request.QueryString["Username"] != null && Request.QueryString["Password"] != null)
    {
    
        if (FormsAuthentication.Authenticate(Request.QueryString["Username"].ToString(), Request.QueryString["Password"].ToString()))
        {
            // Authentication successful code
    
            FormsAuthentication.RedirectFromLoginPage(Request.QueryString["Username"].ToString(), true);
        }
        else
        {
            // Authentication unsuccessful code
        }
    }
    else
    {
        // Parameter invalid or missing code
    }
