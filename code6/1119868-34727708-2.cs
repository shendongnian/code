    protected void Application_PostAuthorizeRequest()
    {
      var context = new HttpContextWrapper(HttpContext.Current);
      var path = context.Request.AppRelativeCurrentExecutionFilePath;
      if (path == null || !path.StartsWith("~/api"))
      {
        return;
      }
      var routeData = RouteTable.Routes.GetRouteData(context);
      if (routeData != null)
      {
        context.SetSessionStateBehavior(routeData.SessionStateBehavior());
      }
    }
