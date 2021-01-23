    /** 
     * Get visitor's ip address.
     */
    public static string GetVisitorIp() {
    	string ip = null;
        if (HttpContext.Current != null) { // ASP.NET
    		ip = string.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"])
    			? HttpContext.Current.Request.UserHostAddress
    			: HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
    	}
        if (string.IsNullOrEmpty(ip) || ip.Trim() == "::1") { // still can't decide or is LAN
    		var lan = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(r => r.AddressFamily == AddressFamily.InterNetwork);
    		ip = lan == null ? string.Empty : lan.ToString();
    	}
    	return ip;
    }
