    [System.Web.Services.WebMethod]
    public static string SetDownloadPath(string strpath)
    {
            HttpContext.Current.Session["strDwnPath"] = strpath;
            return strpath;
    }
