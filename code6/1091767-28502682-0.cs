    using Owin;
    using Microsoft.Owin;
    [assembly: OwinStartup(typeof(YOURNAMESPACE.Startup))]
    namespace YOURNAMESPACE
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                //DO your stuff
            }
        }
    }
