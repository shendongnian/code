    [WebMethod]
    public static int LogoutCheck()
    {
       if (HttpContext.Current.Session["user"] == null)
       {
          return 0;
       }
       return 1;
    }
