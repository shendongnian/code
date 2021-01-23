    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWebApi(new WebApiConfig());
            app.CreatePerOwinContext(MyDbContext.Create);
            app.CreatePerOwinContext<MyUserManager>(MyUserManager.Create);
        }
    }
