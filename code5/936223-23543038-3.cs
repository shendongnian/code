    public class InitializeCultureAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.RouteData.Values.ContainsKey("lang")) return;
                
            var culture = filterContext.RouteData.Values["lang"] as string;
            if (String.IsNullOrEmpty(culture)) return;
            var cultureInfo = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;                
        }
    }
