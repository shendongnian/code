    // File: Bootstrapper.cs (contains class Bootstrapper)
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using WebActivatorEx;
    using WhatEver.It.Is;
    [assembly: PreApplicationStartMethod(typeof(Bootstrapper), "Bootstrap")]
    namespace WhatEver.It.Is {
        public class Bootstrapper {
            public static void Bootstrap() {
                // Do what do you need just before the application get started
                // like registering modules, etc...
                DynamicModuleUtility.RegisterModule(typeof(MyModule));
            }
        }
    }
