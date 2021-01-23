    public class OwinStartup
    {
        private static IDisposable _Server;
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Insert(0, new JsonpFormatter());
            appBuilder.UseWebApi(config);
        }
        public static void Start()
        {
            // If the Start() method throws an exception, the problem
            // is a missing right. The url has to be registered somewhere
            // deep down in windows and this is only allowed by the admin.
            // But you can change this rule to allow this registration for
            // anybody by running the below command within a command prompt
            // with admin rights:
            // netsh http add urlacl url=http://+:14251/ user=Everyone
            // Depending on your OS language the group name can differ.
            string baseAddress = "http://+:26575/";
            try
            {
                _Server = WebApp.Start<OwinStartup>(url: baseAddress);
            }
            catch (HttpListenerException ex)
            {
                _Log.Message(Severity.Fatal, "Could not start web api listener.", ex);
                _Log.Message(Severity.Notice, "This normally happens cause the application is not allowed to add a web listener.");
                _Log.Message(Severity.Debug, "Open up a command prompt with admin rights and execute the following command: \"netsh http add urlacl url="+ baseAddress +" user=Everyone\"");
            }
        }
        public static void Stop()
        {
            if(_Server != null)
            {
                _Server.Dispose();
                _Server = null;
            }
        }
    }
