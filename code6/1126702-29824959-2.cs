    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;
    
    public class CultureAttribute : ActionFilterAttribute {
    public override void OnActionExecuting(ActionExecutingContext filterContext) {
        string language = (string)filterContext.RouteData.Values["language"] ?? "en";
        string culture = (string)filterContext.RouteData.Values["culture"] ?? "US";
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", language, culture));
        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", language, culture));
    }
    }
