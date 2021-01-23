    public class AntiForgeryHandleErrorAttribute : HandleErrorAttribute
        {
            public override void OnException(ExceptionContext context)
            {
                if (context.Exception is HttpAntiForgeryException)
                {
                    var url = string.Empty;
                    if (!context.HttpContext.User.Identity.IsAuthenticated)
                    {
                        var requestContext = new RequestContext(context.HttpContext, context.RouteData);
                        url = RouteTable.Routes.GetVirtualPath(requestContext, new RouteValueDictionary(new {Controller = "User", action = "Login"})).VirtualPath;
                    }
                    else
                    {
                        context.HttpContext.Response.StatusCode = 200;
                        context.ExceptionHandled = true;
                        url = GetRedirectUrl(context);
                    }
                    context.HttpContext.Response.Redirect(url, true);
                }
                else
                {
                    base.OnException(context);
                }
            }
    
            private string GetRedirectUrl(ExceptionContext context)
            {
                try
                {
                    var requestContext = new RequestContext(context.HttpContext, context.RouteData);
                    var url = RouteTable.Routes.GetVirtualPath(requestContext, new RouteValueDictionary(new { Controller = "User", action = "AlreadySignIn" })).VirtualPath;
    
                    return url;
                }
                catch (Exception)
                {
                    throw new NullReferenceException();
                }
            }
        }
