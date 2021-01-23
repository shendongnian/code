    [WebMethod]
    public static string SetSessionValue(string val)
    {
        HttpContext.Current.Session["value"] = val;
        return HttpContext.Current.Session["value"].ToString();
    }
