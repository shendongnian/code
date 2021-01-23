    public class PersonalizeAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string language = (string)(filterContext.RouteData.Values["language"] ?? "en");
            string culture = (string)(filterContext.RouteData.Values["culture"] ?? "US");
            CultureInfo ci = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", language, culture));
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
     public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new PersonalizeAttribute());
        }
