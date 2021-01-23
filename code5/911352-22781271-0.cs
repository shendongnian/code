    public class FilterA : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.RouteData.GetRequiredString("controller").Equals("account", StringComparison.CurrentCultureIgnoreCase) //long condition evaluating to true
                //logic controlling these filters dont apply to Foo/Bar and Foo/Baz
                && (!context.RouteData.GetRequiredString("controller").Equals("Foo", StringComparison.CurrentCultureIgnoreCase)
                    || (!context.RouteData.GetRequiredString("action").Equals("Bar", StringComparison.CurrentCultureIgnoreCase)
                        && !context.RouteData.GetRequiredString("action").Equals("Baz", StringComparison.CurrentCultureIgnoreCase))
                    )
                )
            {
                context.Result = new RedirectResult("~/Foo/Bar");
            }
        }
    }
    public class FilterB : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (true /*long condition evaluating to true*/
                //logic controlling these filters dont apply to Foo/Bar and Foo/Baz
                && (!context.RouteData.GetRequiredString("controller").Equals("Foo", StringComparison.CurrentCultureIgnoreCase)
                    || (!context.RouteData.GetRequiredString("action").Equals("Bar", StringComparison.CurrentCultureIgnoreCase)
                        && !context.RouteData.GetRequiredString("action").Equals("Baz", StringComparison.CurrentCultureIgnoreCase))
                    )
                )
            {
                context.Result = new RedirectResult("~/Foo/Baz");
            }
        }
    }
