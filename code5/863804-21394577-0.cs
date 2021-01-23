    public class MyService : IMyService
    {
        private readonly IMyOtherService _myOtherService;
    
        // Services will be recursively resolved by Katana's IServiceProvider
        public MyService(IMyOtherService myOtherService)
        {
            _myOtherService = myOtherService;
        }
    
        // Implementation
    }
    public class Startup
    {
       private readonly IMyService _myService;
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
    using Microsoft.Owin.Hosting.Engine;
    using Microsoft.Owin.Hosting.Services;
    using Microsoft.Owin.Hosting.Starter;
    using Owin;
    public class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:8080";
            IServiceProvider services = ServicesFactory.Create();
            var options = new StartOptions(url);
            services.Add<IMyOtherService, MyOtherService>();
            services.Add<IMyService, MyService>();
            var starter = services.GetService<IHostingStarter>();
            return starter.Start(options);
        }
    }
