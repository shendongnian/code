    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
      AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
      LoginPath = new PathString("/Account/Login"),
      Provider = new CookieAuthenticationProvider
      {
        OnApplyRedirect = ctx =>
        {
          if (!IsAjaxRequest(ctx.Request))
          {
            ctx.Response.Redirect(ctx.RedirectUri);
          }
        }
      }
    });
    private static bool IsAjaxRequest(IOwinRequest request)
    {
      IReadableStringCollection query = request.Query;
      if ((query != null) && (query["X-Requested-With"] == "XMLHttpRequest"))
      {
         return true;
      }
      IHeaderDictionary headers = request.Headers;
      return ((headers != null) && (headers["X-Requested-With"] == "XMLHttpRequest"));
    }
