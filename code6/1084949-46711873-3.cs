        [assembly: **OwinStartupAttribute**(typeof(Project-Name.Startup))]
        namespace project-name
        {
            public partial class Startup
            {
                public void **ConfigureAuth**(IAppBuilder app)
                        {
