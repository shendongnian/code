     public class Startup
     {
        public void Configuration(IAppBuilder app)
        {
        app
            .Use<CustomExceptionMiddleware>()
            .UseWebApi();
        }
    }
