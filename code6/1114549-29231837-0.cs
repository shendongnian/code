    // Tell OWIN to start with this
    [assembly: OwinStartup(typeof(MyWebApi.Startup))]
    namespace MyWebApi
    {
        public class Startup
        {
            /// <summary>
            /// This method gets called automatically by OWIN when the application starts, it will pass in the IAppBuilder instance.
            /// The WebApi is registered here and one of the built in shortcuts for using the WebApi is called to initialise it.
            /// </summary>
            public void Configuration(IAppBuilder app)
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                app.UseWebApi(config);
            }
        }
    }
