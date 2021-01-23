    public static class AutofacExtensions
    {
        private static readonly ProxyGenerator generator = new ProxyGenerator();
        /// <summary>
        /// Intercept ALL registered interfaces with provided interceptors.
        /// Override Autofac activation with a Interface Proxy.
        /// Does not intercept classes, only interface bindings.
        /// </summary>
        /// <param name="builder">Contained builder to apply interceptions to.</param>
        /// <param name="interceptors">List of interceptors to apply.</param>
        public static void InterceptInterfacesBy(this ContainerBuilder builder, params IInterceptor[] interceptors)
        {
            builder.RegisterCallback((componentRegistry) =>
            {
                foreach (var registration in componentRegistry.Registrations)
                {
                    InterceptRegistration(registration, interceptors);
                }
            });
        }
        /// <summary>
        /// Intercept a specific component registrations.
        /// </summary>
        /// <param name="registration">Component registration</param>
        /// <param name="interceptors">List of interceptors to apply.</param>
        private static void InterceptRegistration(IComponentRegistration registration, params IInterceptor[] interceptors)
        {
            registration.Activating += (sender, e) =>
            {
                if (e.Component.Activator.LimitType.IsInterface &&
                    // prevent proxiyng the proxy 
                    e.Instance.GetType().Namespace != "Castle.Proxies")
                {
                    var proxiedInterfaces = e.Instance.GetType().GetInterfaces().Where(i => i.IsVisible).ToArray();
                    if (!proxiedInterfaces.Any())
                    {
                        return;
                    }
                    var theInterface = proxiedInterfaces.First();
                    var interfaces = proxiedInterfaces.Skip(1).ToArray();
                    e.Instance = generator.CreateInterfaceProxyWithTarget(theInterface, interfaces, e.Instance, interceptors);
                }
            };
        }
    }
