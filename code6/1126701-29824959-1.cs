    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;
    
    public class CultureAttribute : ActionFilterAttribute {
    public override void OnActionExecuting(ActionExecutingContext filterContext) {
        string language = (string)filterContext.HttpContext.Session.Contents["language"] ?? "en";
        string culture = (string)filterContext.HttpContext.Session.Contents["culture"] ?? "US";
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", language, culture));
        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", language, culture));
    }
}
