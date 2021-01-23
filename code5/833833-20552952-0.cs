    [WebMethod(EnableSession = true)]
    public static string GetLoggedInUserName()
    {
        return HttpContext.Current.Session["User"].ToString();
    }
