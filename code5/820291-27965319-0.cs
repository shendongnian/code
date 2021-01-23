    public static bool IsDebugWebServer()
    {
      if (HttpContext.Current != null && HttpContext.Current.Request != null)
      {
        return HttpContext.Current.Request.ServerVariables["SERVER_SOFTWARE"] == null || HttpContext.Current.Request.ServerVariables["SERVER_SOFTWARE"] == string.Empty;
      }
    else
      {
        return false;
      }
    }
