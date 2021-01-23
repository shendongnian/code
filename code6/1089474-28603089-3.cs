      private static ActionResult UnauthorizedAccessExceptionResult(ExceptionContext filterContext)
        {
            // Send email, fire event, add error messages 
            //  for example handle error messages
            //you can seperate the behaviour by: if (filterContext.HttpContext.Request.IsAjaxRequest())
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            filterContext.Controller.TempData.Add(MessageType.Danger.ToString(), filterContext.Exception.Message);
           //So you can show messages using with TempData["Key"] on your action or views
           var lRoutes = new RouteValueDictionary(
                new
                    {
                        action = filterContext.RouteData.Values["action"],
                        controller = filterContext.RouteData.Values["controller"]
                    });
            return new RedirectToRouteResult(lRoutes);
        }
