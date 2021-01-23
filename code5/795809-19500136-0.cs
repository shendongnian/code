    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapPath("/site", siteBuilder => siteBuilder.UseNancy());
        }
    }
