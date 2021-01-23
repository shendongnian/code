     `function InitializeRequest(path) 
    {
                // call server side method
                PageMethods.SetDownloadPath(path);
    }`
    [System.Web.Services.WebMethod]
    public static string SetDownloadPath(string strpath)
    {
        Page objp = new Page();
        objp.Session["strDwnPath"] = strpath; 
        return strpath;
    }
