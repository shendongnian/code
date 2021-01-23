    public static string getIPAddress(HttpRequestBase request)
    {
        string szRemoteAddr = request.UserHostAddress;
        string szXForwardedFor = request.ServerVariables["X_FORWARDED_FOR"];
        string szIP = "";
        if (szXForwardedFor == null)
        {
            szIP = szRemoteAddr;
        }
        else
        {
            szIP = szXForwardedFor;
            if (szIP.IndexOf(",") > 0)
            {
                string [] arIPs = szIP.Split(',');
                foreach (string item in arIPs)
                {
                    if (!isPrivateIP(item))
                    {
                        return item;
                    }
                }
            }
        }
        return szIP;
    }
