    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "Default",
                "{controller}/{id}",
                new { id = RouteParameter.Optional }
                );
            builder.Use<CustomExceptionMiddleware>().UseWebApi(config);
        }
    }
