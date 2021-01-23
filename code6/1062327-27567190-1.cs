    namespace Web.UI.Models.Errors
    {
        public static class ErrorConfig
        {
            public static void Handle(HttpContext context)
            {
                switch (context.Response.StatusCode)
                {
                    case 401:
                        Show(context, 401);
                        break;
                    case 404:
                        Show(context, 404);
                        break;
                    case 500:
                        Show(context, 500);
                       break;
                }
            }
            //TODO uncomment 500 error
            static void Show(HttpContext context, Int32 code)
            {
                context.Response.Clear();
    
                var w = new HttpContextWrapper(context);
                var c = new ErrorController() as IController;
                var rd = new RouteData();
    
                rd.Values["controller"] = "Error";
                rd.Values["action"] = "Index";
                rd.Values["id"] = code.ToString(CultureInfo.InvariantCulture);
    
                c.Execute(new RequestContext(w, rd));
            }
        }
    }
