    public static string GetIp(this HttpContextBase context)
    {
        if (context == null || context.Request == null)
            return string.Empty;
        return context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] 
               ?? context.Request.UserHostAddress;
    }
