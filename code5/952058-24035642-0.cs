    public string FullyQualifiedApplicationPath
    {
      get
      {
        //Return variable declaration
        string appPath = null;
    
        //Getting the current context of HTTP request
        HttpContext context = HttpContext.Current;
    
        //Checking the current context content
        if (context != null)
        {
          //Formatting the fully qualified website url/name
          appPath = string.Format("{0}://{1}{2}{3}",
            context.Request.Url.Scheme,
            context.Request.Url.Host,
            context.Request.Url.Port == 80
              ? string.Empty : ":" + context.Request.Url.Port,
            context.Request.ApplicationPath);
        }
        if (!appPath.EndsWith("/"))
          appPath += "/";
        return appPath;
      }
    }
