    /// <summary>
    /// Get current user ip address.
    /// </summary>
    /// <returns>The IP Address</returns>
    public static string GetUserIPAddress()
    {
        var context = System.Web.HttpContext.Current;
        string ip = String.Empty;
    
        if (context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        else if (!String.IsNullOrWhiteSpace(context.Request.UserHostAddress))
            ip = context.Request.UserHostAddress;
    
        if (ip == "::1")
            ip = "127.0.0.1";
    
        return ip;
    }
