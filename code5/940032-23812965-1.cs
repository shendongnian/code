    using Microsoft.Owin;
    using Owin;
    [assembly: OwinStartup(typeof(YOUR_NAME_SPACE_TO_THE_STARTUP_FILE.Startup))]
    namespace YOUR_NAME_SPACE_TO_THE_STARTUP_FILE
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                ConfigureAuth(app);
            }
        }
    }
