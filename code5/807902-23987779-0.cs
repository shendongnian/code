    using Microsoft.Owin;
    using Owin;
    
    [assembly: OwinStartupAttribute(typeof(MyProjectNamespace.Startup))]
    namespace MyProjectNamespace
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                //ConfigureAuth(app);
            }
        }
    }
