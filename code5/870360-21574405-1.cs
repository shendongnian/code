    using System;
    using ServiceStack;
    namespace TestCookies
    {
        class MainClass
        {
            public static void Main()
            {
                // Very basic console host
                var appHost = new AppHost(500);
                appHost.Init();
                appHost.Start("http://*:9000/");
                // Make client request
                var client = new JsonServiceClient("http://localhost:9000");
                Console.WriteLine("Has cookie? {0}", client.Get(new HasCookieRequest()));
                client.Get(new SetCookieRequest());
                Console.WriteLine("Set cookie? {0}", client.CookieContainer.Count > 0);
                Console.WriteLine("Has cookie? {0}", client.Get(new HasCookieRequest()));
                Console.ReadKey();
            }
        }
        public class AppHost : AppHostHttpListenerPoolBase
        {
            public AppHost(int poolSize) : base("Cookie Test Service", poolSize, typeof(CookieTestService).Assembly) {}
            public override void Configure(Funq.Container container)
            {
                Config = new HostConfig {
                    DebugMode = true,
                };
            }
        }
        [Route("/SetCookie","GET")]
        public class SetCookieRequest : IReturnVoid {}
        [Route("/HasCookie","GET")]
        public class HasCookieRequest : IReturn<bool> {}
        public class CookieTestService : Service
        {
            public void Get(SetCookieRequest request)
            {
                Response.SetCookie("ss-id","1234567890",DateTime.Now.AddDays(1));
            }
            public bool Get(HasCookieRequest request)
            {
                return Request.Cookies.ContainsKey("ss-id");
            }
        }
    }
