    public class GrossGalsFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["HasConfirmed"] == null
                                        && TerminalUserData.IsGrossGallonTerminal)
            {
                filterContext.Result =
                    new RedirectToRouteResult(new RouteValueDictionary(new
                    { controller = "MyController", action = "ConversionFactors" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
