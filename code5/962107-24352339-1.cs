    public static class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            var httpConfig = new HttpConfiguration();
            httpConfig.Routes.MapHttpRoute("Default", "api/{controller}/{id}",
                                           new {id = RouteParameter.Optional});
            app.UseWebApi(httpConfig);
            app.MapSignalR();
        }
    }
