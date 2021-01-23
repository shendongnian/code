    public static string GetClientIP()
    {
        try
        {
            string VisitorsIPAddress = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddress = HttpContext.Current.Request.UserHostAddress;
            }
            return VisitorsIPAddress;
        }
        catch (Exception)
        {
            return null;
        }
    }
