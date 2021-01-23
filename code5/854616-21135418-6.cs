    using ServiceStack.CacheAccess;
    using ServiceStack.CacheAccess.Providers;
    using ServiceStack.ServiceInterface;
    using ServiceStack.ServiceInterface.Auth;
    using ServiceStack.ServiceHost;
    using ServiceStack.WebHost.Endpoints;
    namespace Testv3
    {
        class MainClass
        {
            public static void Main()
            {
                // Very basic console host
                var appHost = new AppHost();
                appHost.Init();
                appHost.Start("http://*:8082/");
                Console.ReadKey();
            }
        }
        public class AppHost : AppHostHttpListenerBase
        {
            public AppHost() : base("Test Service", typeof(TestApp).Assembly) {}
            public override void Configure(Funq.Container container)
            {
                // Cache and session IoC
                container.Register<ICacheClient>(new MemoryCacheClient());
                container.Register<ISessionFactory>(c => new SessionFactory(c.Resolve<ICacheClient>()));
                // Register the Auth Feature with the CustomCredentialsAuthProvider.
                Plugins.Add(new AuthFeature(
                    () => new CustomUserSession(), 
                    new IAuthProvider[]
                    {
                        new CustomCredentialsAuthProvider(),
                        new BasicAuthProvider(),
                    })
                );
            }
        }
        public class CustomCredentialsAuthProvider : CredentialsAuthProvider
        {
            public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
            {
                // Replace with a database lookup
                return (userName == "clark.kent" && password == "kryptonite");
            }
            public override void OnAuthenticated(IServiceBase authService, IAuthSession session, IOAuthTokens tokens, Dictionary<string, string> authInfo)
            {
                var customSession = session as CustomUserSession;
                if(customSession != null)
                {
                    // Replace these static values with a database lookup
                    customSession.FirstName = "Clark";
                    customSession.LastName = "Kent";
                    customSession.SuperHeroIdentity = "Superman";
                }
                authService.SaveSession(customSession, SessionExpiry);
            }
        }
        public class CustomUserSession : AuthUserSession 
        {
            // Our added session property
            public string SuperHeroIdentity { get; set; }
        }
        public static class TestApp
        {
            [Route("/SuperHeroTime", "GET")]
            public class SuperHeroTimeRequest {}
            public class TestController : Service
            {
                public CustomUserSession CustomUserSession
                {
                    get 
                    { 
                        // Returns the typed session
                        return SessionAs<CustomUserSession>(); 
                    }
                }
                [Authenticate]
                public object Get(SuperHeroTimeRequest request)
                {
                    // Return the result object
                    return new { CustomUserSession.FirstName, CustomUserSession.LastName, Time = DateTime.Now.ToString(), CustomUserSession.SuperHeroIdentity };
                }
            }
        }
    }
