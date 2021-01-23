    using System;
    using System.Threading;
    using DI06.Services;
    using DI06.Services.Contracts;
    using StructureMap;
    
    namespace DI06.IocConfig
    {
        public static class SmObjectFactory
        {
            private static readonly Lazy<Container> _containerBuilder =
                new Lazy<Container>(defaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);
    
            public static IContainer Container
            {
                get { return _containerBuilder.Value; }
            }
    
            private static Container defaultContainer()
            {
                return new Container(x =>
                {
                    x.For<ILogActionService>().Use<LogActionService>();
    
                    x.Policies.SetAllProperties(y =>
                    {
                        y.OfType<ILogActionService>();
                    });
                });
            }
        }
    }
