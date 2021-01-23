    using Microsoft.AspNet.SignalR;
    using Microsoft.Owin.Security;
    using Owin;
    //add the attribute here
    [assembly: OwinStartup(typeof(SignalRTutorials.Startup))]
    namespace SignalRTutorials
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.MapSignalR();
            }
        }
    }
