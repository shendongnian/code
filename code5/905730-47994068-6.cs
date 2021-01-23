    using Microsoft.Owin;
    using System.Web;
    IOwinContext context = HttpContext.Current.GetOwinContext();
    // or
    IOwinContext context = HttpContext.Current.Request.GetOwinContext();
