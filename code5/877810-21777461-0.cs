    public class DefaultController : Umbraco.Web.Mvc.SurfaceController
    {
       Public ActionResult YourMethod()
       {
           return CurrentUmbracoPage();
       }
    }
