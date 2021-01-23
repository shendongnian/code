    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/site", siteBuilder => siteBuilder.UseNancy())
               .MapSignalR();
        }
    }
