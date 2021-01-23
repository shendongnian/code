    using System;
    using ServiceStack;
     
    namespace Testv4
    {
        class MainClass
        {
            public static void Main()
            {
                var appHost = new AppHost(500);
                appHost.Init();
                appHost.Start("http://*:8082/");
                Console.ReadKey();
            }
        }
     
        public class TestApp
        {
            [Route("/upload", "POST")]
            public class UploadFileRequest {}
     
            public class TestController : Service
            {
                public void Any(UploadFileRequest request)
                {
                    Console.WriteLine(Request.Files.Length);
                }
            }
        }
     
        public class AppHost : AppHostHttpListenerPoolBase
        {
            public AppHost(int poolSize) : base("Test Service", poolSize, typeof(TestApp).Assembly)
            {
            }
     
            public override void Configure(Funq.Container container)
            {
            }
        }
    }
