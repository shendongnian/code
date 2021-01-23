    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<ClassIWantOneInstancePerContext>(ClassIWantOneInstancePerContext.Create);
            //other code...
        }
    }
