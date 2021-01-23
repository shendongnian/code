    public class LocalizationAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var culture = filterContext.RouteData.Values["culture"] as string;
            var userLanguage = HttpContext.Current.Request.UserLanguages;
            
            CultureInfo cultureInfo = new CultureInfo(culture ?? (userLanguage != null ? userLanguage[0].Substring(0, 2) : "sv"));
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
            base.OnActionExecuting(filterContext);
        }
    }
