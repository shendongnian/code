    public class MyService : IMyService
    {
        private readonly IMyOtherService _myOtherService;
    
        // Services will be recursively resolved by Katana's ServiceProvider
        public MyService(IMyOtherService myOtherService)
        {
            _myOtherService = myOtherService;
        }
    
        // Implementation
    }
    public class Startup
    {
       private readonly IMyService _myService;
       // Startup must have exactly one constructor.
       public Startup(IMyService myService)
       {
           _myService = myService
       }
       public void Configuration(IAppBuilder app)
       {
           app.MapSignalR(new HubConfiguration { Resolver = ... });
       }
    }
---
    using System;
    using Microsoft.Owin.Hosting;
    using Microsoft.Owin.Hosting.Services;
    using Microsoft.Owin.Hosting.Starter;
    public class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:8080";
            var services = (ServiceProvider)ServicesFactory.Create();
            var options = new StartOptions(url);
            services.Add<IMyOtherService, MyOtherService>();
            services.Add<IMyService, MyService>();
            var starter = services.GetService<IHostingStarter>();
            using (starter.Start(options)) // constructs Startup instance internally
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
