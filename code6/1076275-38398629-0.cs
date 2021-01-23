    using System;
    using Autofac;
    using Hangfire;
    
    namespace MyApp.DependencyInjection
    {
        public class ContainerJobActivator : JobActivator
        {
            [ThreadStatic]
            private static ILifetimeScope _jobScope;
            private readonly IContainer _container;
    
            public ContainerJobActivator(IContainer container)
            {
                _container = container;
            }
    
            public void BeginJobScope()
            {
                _jobScope = _container.BeginLifetimeScope();
            }
    
            public void DisposeJobScope()
            {
                _jobScope.Dispose();
                _jobScope = null;
            }
    
            public override object ActivateJob(Type type)
            {
                return _jobScope.Resolve(type);
            }
        }
    }
