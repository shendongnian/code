    if(string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
    {
        FormsAuthentication.SetAuthCookie(tbUserName.Text, false);
        
        if (HttpContext.Current.User.IsInRole(ADMIN))
        {
            Response.Redirect(ADMIN_URL, true);
        }
        else if (HttpContext.Current.User.IsInRole(USER))
        {
            Response.Redirect(USER_URL, true);
        }
        else if (HttpContext.Current.User.IsInRole(DEALER))
        {
            Response.Redirect(DEALER_URL, true);
        }
        else if (HttpContext.Current.User.IsInRole(OPERATOR))
        {
            Response.Redirect(OPERATOR_URL, true);
        }
        else
        {
            Response.Redirect(SOME_DEFAULT_URL, true);
        }
    }
    else
    {
        FormsAuthentication.RedirectFromLoginPage(tbUserName.Text, false);
    }
