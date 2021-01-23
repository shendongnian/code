    [assembly: OwinStartupAttribute(typeof(YourNamespace.Startup))]
    namespace YourNamespace
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                ConfigureAuth(app);
            }
        }
    }
