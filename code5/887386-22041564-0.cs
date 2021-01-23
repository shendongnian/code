    public static string GetUserIpAddress()
    {
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(ip))
        {
            ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (ip == "::1") ip = "127.0.0.1"; // localhost
        }
        return ip;
    }
