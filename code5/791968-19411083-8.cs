    public class MvcApplication : HttpApplication
    {
        protected override void OnApplicationStarted()
        {
           // ...
           FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
           // ...
        }
    }
