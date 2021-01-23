    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Web.Http.Dependencies;
    using Ninject;
    using Ninject.Syntax;
    
    namespace YourAppNameSpace
    {
        public class NinjectDependencyScope : IDependencyScope
        {
            private IResolutionRoot _resolver;
    
            internal NinjectDependencyScope(IResolutionRoot resolver)
            {
                Contract.Assert(resolver != null);
                _resolver = resolver;
            }
    
            public void Dispose()
            {
                var disposable = _resolver as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
    
                _resolver = null;
            }
    
            public object GetService(Type serviceType)
            {
                if (_resolver == null)
                {
                    throw new ObjectDisposedException("this", "This scope has already been disposed");
                }
    
                return _resolver.TryGet(serviceType);
            }
    
            public IEnumerable<object> GetServices(Type serviceType)
            {
                if (_resolver == null)
                {
                    throw new ObjectDisposedException("this", "This scope has already been disposed");
                }
    
                return _resolver.GetAll(serviceType);
            }
        }
    }
