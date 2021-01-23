    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    internal sealed class DoLocalizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string cultureName = filterContext.RouteData.Values["lang"].ToString();
            SpecificCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = SpecificCulture;
            Thread.CurrentThread.CurrentUICulture = SpecificCulture;
        }
        public CultureInfo SpecificCulture { get; set; }
    }
