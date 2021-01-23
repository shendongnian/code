    public static String GetCookie(String cookieName)
    {
       try
       {
          if (HttpContext.Current.Request.Cookies[cookieName] == null)
             return String.Empty;
    
          return HttpContext.Current.Request.Cookies[cookieName].Value;
       }
       catch
       {
          return String.Empty;
       }
    }
