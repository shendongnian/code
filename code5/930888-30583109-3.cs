    using Owin;
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<OwnExceptionMiddleware>()
               .UseNancy();
        }
    }
