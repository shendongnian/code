    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app
                .IgnoreWCFRequests()
                .UseWebApi(config)
                .Run(context =>
                {
                    return context.Response.WriteAsync("Default Response");
                });
        }
    }
