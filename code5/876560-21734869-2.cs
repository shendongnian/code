    public CustomAuthorizeAttribute : AuthorizeAttribute
    {
      protected override bool AuthorizeCore(HttpContextBase httpContext)
      {
        // do OAuth checking
        if (HttpContext.Current.Request.Path 
        or HttpContext.Current.Request.QueryString["OAuthToke"].Equals())
        {
          return true;
        }
        return base.AuthorizeCore(httpContext);
      }
    }
