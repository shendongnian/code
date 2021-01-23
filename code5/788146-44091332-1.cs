    Private string getExternalIp()
    {
    try
    {
        string externalIP;
        externalIP = (new 
        WebClient()).DownloadString("http://checkip.dyndns.org/");
        externalIP = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"))
                     .Matches(externalIP)[0].ToString();
        return externalIP;
    }
    catch { return null; }
    }
