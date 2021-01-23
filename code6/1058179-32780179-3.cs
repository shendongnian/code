    using System;
    using Microsoft.AspNet.Builder;
    using Microsoft.Framework.DependencyInjection;
    using Messenger.Services;
    using Microsoft.Framework.Configuration;
    using Microsoft.Dnx.Runtime;
    using Microsoft.AspNet.Hosting;
    
    namespace Messenger
    {
        public class Startup
        {
            public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
            {
                var configurationBuilder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                    .AddJsonFile("config.json")
                    .AddEnvironmentVariables();
                Configuration = configurationBuilder.Build();
            }
    
            public IConfiguration Configuration { get; set; }
        }
    ...
    }
